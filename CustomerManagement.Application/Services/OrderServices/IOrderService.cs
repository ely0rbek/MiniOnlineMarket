using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.OrderServices
{
    public interface IOrderService
    {
        public Task<Order> CreateOrder(int userId,OrderDTO orderDTO);
        public Task<IEnumerable<Order>> GetAllOrders(int userId);
        public Task<IEnumerable<Order>> GetOrderByName(int userId,string productName);
        public Task<Order> UpdateOrderById(int orderId, OrderDTO orderDTO);
        public Task<bool> DeleteOrderById(int orderId);
    }
}
