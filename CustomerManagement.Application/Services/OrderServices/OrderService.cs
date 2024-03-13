using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Infrastructure.Repositories.OrderRepositories;
using CustomerManagement.Infrastructure.Repositories.PersonRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPersonRepository _personRepository;

        public OrderService(IOrderRepository orderRepository, IPersonRepository personRepository)
        {
            _orderRepository = orderRepository;
            _personRepository = personRepository;
        }

        public async Task<Order> CreateOrder(int userId, OrderDTO orderDTO)
        {
            var user = await _personRepository.GetByAny(x => x.Id == userId);
            var newOrder = new Order() 
            { 
                PersonId = userId,
                PersonName=user.Name,
                ProductId=orderDTO.ProductId,
                ProductName=orderDTO.ProductName,
                ProductAmount=orderDTO.ProductAmount
            };
            return await _orderRepository.Create(newOrder);
        }

        public async Task<bool> DeleteOrderById(int orderId)
        {
            return await _orderRepository.Delete(x=>x.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetAllOrders(int userId)
        {
            var allOrders = await _orderRepository.GetAll();
            var myAllOrders = new List<Order>();
            foreach (var order in allOrders)
            {
                if (order.PersonId == userId)
                    myAllOrders.Add(order);
            }
            return myAllOrders;
        }

        public async Task<IEnumerable<Order>> GetOrderByName(int userId, string productName)
        {
            var allOrders = await _orderRepository.GetAll();
            var myAllOrders = new List<Order>();
            foreach (var order in allOrders)
            {
                if (order.PersonId == userId && order.ProductName==productName)
                    myAllOrders.Add(order);
            }
            return myAllOrders;
        }
        public async Task<Order> UpdateOrderById(int orderId, OrderDTO orderDTO)
        {
            var oldOrder=await _orderRepository.GetByAny(x=>x.Id==orderId);
            oldOrder.ProductId = orderDTO.ProductId;
            oldOrder.ProductName = orderDTO.ProductName;
            oldOrder.ProductId = orderDTO.ProductId;
            return await _orderRepository.Update(oldOrder);
        }
    }
}
