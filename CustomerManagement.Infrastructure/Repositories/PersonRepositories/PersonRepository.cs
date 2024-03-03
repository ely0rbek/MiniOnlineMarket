using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Infrastructure.Persistance;
using CustomerManagement.Infrastructure.Repositories.BaseRepositories;

namespace CustomerManagement.Infrastructure.Repositories.PersonRepositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(InfrastructureDbContext context) : base(context)
        {
        }
    }
}
