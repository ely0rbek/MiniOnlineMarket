using CustomerManagement.API.Attributes;
using CustomerManagement.API.ExternalServices;
using CustomerManagement.Application.Services.PersonServices;
using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetAllPersons)]
        public async Task<IActionResult> GetAllPersons()
        {
            return Ok(await _personService.GetAllPersons());
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetPersonById)]
        public async Task<IActionResult> GetPersonById(int id)
        {
            return Ok(await _personService.GetPersonById(id));
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetPersonByName)]
        public async Task<IActionResult> GetPersonByName(string ProductName)
        {
            return Ok(await _personService.GetPersonByName(ProductName));
        }

        [HttpPut]
        [IdentityFilter(Permissions.UpdatePersonAccount)]
        public async Task<IActionResult> UpdatePersonAccount(PersonDTO personDTO)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = SolveToken.DecodeJwtToken(token, "assalomejesbsjjsbdewbiebelykubvulgborbek");
            return Ok(await _personService.UpdateAccount(Convert.ToInt32(userId),personDTO));
        }
        [HttpDelete]
        [IdentityFilter(Permissions.DeletePersonById)]
        public async Task<bool> DeletePersonById(int id)
        {
            return await _personService.DeletePerson(id);
        }
    }
}
