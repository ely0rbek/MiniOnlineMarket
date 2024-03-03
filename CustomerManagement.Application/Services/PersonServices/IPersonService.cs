using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Models;

namespace CustomerManagement.Application.Services.PersonServices
{
    public interface IPersonService
    {
        public Task<PersonDTO> UpdateAccount(int personId,PersonDTO personDTO);
        public Task<IEnumerable<Person>> GetAllPersons();
        public Task<Person> GetPersonById(int personId);
        public Task<Person> GetPersonByName(string personName);
        public Task<bool> DeletePerson(int personId);

    }
}
