using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Infrastructure.Repositories.PersonRepositories;
using CustomerManagement.Infrastructure.Repositories.ProductRepositories;

namespace CustomerManagement.Application.Services.PersonServices
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> DeletePerson(int personId)
        {
            return await _personRepository.Delete(x=>x.Id == personId);
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await _personRepository.GetAll();
        }

        public async Task<Person> GetPersonById(int personId)
        {
            return await _personRepository.GetByAny(x=>x.Id == personId);
        }
        public async Task<Person> GetPersonByName(string personName)
        {
            return await _personRepository.GetByAny(x => x.Name == personName);
        }

        public async Task<PersonDTO> UpdateAccount(int personId, PersonDTO personDTO)
        {
            var oldUser=await _personRepository.GetByAny(x=>x.Id== personId);
            if (oldUser != null)
            {
                if(personDTO.Surname!="string") oldUser.Surname = personDTO.Surname;
                if (personDTO.Name != "string") oldUser.Name = personDTO.Name;
                if (personDTO.Email != "user@example.com") oldUser.Email = personDTO.Email;
                if (personDTO.Password != "string") oldUser.Password = personDTO.Password;

                var result= await _personRepository.Update(oldUser);
                return personDTO;
            }
            else return null;
        }
    }
}
