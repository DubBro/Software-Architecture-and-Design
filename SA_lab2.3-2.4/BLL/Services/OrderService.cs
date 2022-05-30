using BLL.DTOs;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class OrderService : Service, IOrderService
    {
        public OrderService(IUnitOfWork database) : base(database)
        {
        }

        public void AddOrder(OrderDTO order)
        {
            if (order == null || !order.Dishes.Any())
            {
                throw new InvalidOrderException();
            }

            database.Orders.Add(mapper.Map<OrderDTO, Order>(order));
            database.Commit();
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(database.Orders.GetAll());
        }
    }
}
