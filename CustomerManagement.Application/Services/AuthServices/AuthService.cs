using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Infrastructure.Repositories.AdminRepositories;
using CustomerManagement.Infrastructure.Repositories.PersonRepositories;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using CustomerManagement.Domain.Entities.Enums;
using System.Text.Json;
using CustomerManagement.Infrastructure.Repositories.RolePermissionsRepositories;

namespace CustomerManagement.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IPersonRepository _personRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IAdminRepository _adminRepository;

        public AuthService(IConfiguration configuration, IPersonRepository personRepository, IRolePermissionRepository rolePermissionRepository, IAdminRepository adminRepository)
        {
            _configuration = configuration;
            _personRepository = personRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _adminRepository = adminRepository;
        }

        public async Task<string> CreateAccount(PersonDTO personDTO, string imagePath)
        {
            var user = await _personRepository.GetByAny(x => x.Email == personDTO.Email);
            if (user != null) { return "Siz oldin ro'yxatdan o'tgansiz"; }
            else
            {
                var content = await _rolePermissionRepository.GetByAny(x => x.Id == personDTO.UserRole);
                //var content = await _adminRepository.GetPermissionByRoleId(personDTO.UserRole);
                var jsonContent = JsonSerializer.Serialize(content.Permissions);
                var newAccount = new Person()
                {
                    Name = personDTO.Name,
                    Surname = personDTO.Surname,
                    Email = personDTO.Email,
                    UserRole=personDTO.UserRole,
                    Password = personDTO.Password,
                    PicturePath = imagePath,
                    Permissions = content.Permissions
                };
                var result = await _personRepository.Create(newAccount);
                var isAdmin = await _rolePermissionRepository.GetByAny(x => x.RoleName == "admin");
                if (newAccount.UserRole == isAdmin.Id)
                {
                    var newAdmin = new Admin()
                    {
                        UserId=newAccount.Id,
                        LimitAdmin=5,
                        AdminPermissions= content.Permissions
                    };
                    var returnAdmin=await _adminRepository.Create(newAdmin);
                }
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, result.UserRole.ToString()),
                    new Claim("Name", result.Name),
                    new Claim("Id", result.Id.ToString()),
                    new Claim("CreatedDate", DateTime.UtcNow.ToString()),
                    new Claim("Permissions", jsonContent),
                };
                return await GenerateToken(claims);
            }

        }

        public async Task<string> GenerateToken(IEnumerable<Claim> additionalClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var exDate = Convert.ToInt32(_configuration["JWT:ExpireDate"] ?? "10");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);


            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(exDate),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _personRepository.GetByAny(x => x.Email == email);
            if (user == null) { return "Siz oldin ro'yxatdan o'tishingiz kerak!"; }
            else if (user.Password != password) { return "Parol yoki email xato"; }
            else
            {
                var content = await _rolePermissionRepository.GetByAny(x => x.Id == user.UserRole);
                //var content = await _adminRepository.GetPermissionByRoleId(user.UserRole);
                var jsonContent= JsonSerializer.Serialize(content.Permissions);
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, user.UserRole.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("CreatedDate", DateTime.UtcNow.ToString()),
                    new Claim("Permissions", jsonContent),
                };
                return await GenerateToken(claims);
            }
        }
    }
}
