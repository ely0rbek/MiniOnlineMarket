using CustomerManagement.API.ExternalServices;
using CustomerManagement.Application.Services.AuthServices;
using CustomerManagement.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class aAuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public aAuthController(IAuthService authService, IWebHostEnvironment webHostEnvironment)
        {
            _authService = authService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromForm] PersonDTO personDTO, IFormFile picture)
        {
            try
            {
                SavePictureExternalService service = new SavePictureExternalService(_webHostEnvironment);
                string imagePath=await service.AddPictureAndGetPath(picture);
                return Ok( _authService.CreateAccount(personDTO,imagePath).Result);
            }
            catch
            {
                return BadRequest("Yaratishda xatolik");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                return Ok(await _authService.Login(email, password));
            }
            catch
            {
                return BadRequest("Kirishda xatolik");
            }
        }
    }
}
