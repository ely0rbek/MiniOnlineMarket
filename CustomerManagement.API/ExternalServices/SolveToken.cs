using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CustomerManagement.API.ExternalServices
{
    public static class SolveToken
    {
        public static string DecodeJwtToken(string token, string secretKey)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);

                // Configure Token Validation Parameters
                var tokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                // Decode Token
                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                // Extract ID from claims
                var id = claimsPrincipal.FindFirst("Id").Value;

                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error decoding JWT token: " + ex.Message);
                return null;
            }
        }

    }
}
