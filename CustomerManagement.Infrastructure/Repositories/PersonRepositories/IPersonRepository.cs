using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Infrastructure.Repositories.BaseRepositories;

namespace CustomerManagement.Infrastructure.Repositories.PersonRepositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
    }
}
