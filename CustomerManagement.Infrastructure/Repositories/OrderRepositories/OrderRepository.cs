using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Infrastructure.Persistance;
using CustomerManagement.Infrastructure.Repositories.BaseRepositories;


namespace CustomerManagement.Infrastructure.Repositories.OrderRepositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(InfrastructureDbContext context) : base(context)
        {
        }
    }
}
