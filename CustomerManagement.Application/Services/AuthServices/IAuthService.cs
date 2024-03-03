using CustomerManagement.Domain.Entities.DTOs;

namespace CustomerManagement.Application.Services.AuthServices
{
    public interface IAuthService
    {
        public Task<string> CreateAccount(PersonDTO personDTO, string Imagepath);
        public Task<string> Login(string email, string password);
    }
}
