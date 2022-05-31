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

        public void UpdateOrder(OrderDTO orderDTO)
        {
            var order = database.Orders.Get(orderDTO.ID);

            if (order == null || !orderDTO.Dishes.Any())
            {
                throw new InvalidOrderException();
            }

            order.Details = orderDTO.Details;
            order.Dishes = mapper.Map<IEnumerable<DishDTO>, IEnumerable<Dish>>(orderDTO.Dishes);

            database.Orders.Update(order);
            database.Commit();
        }

        public void DeleteOrder(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            database.Orders.Delete(id);
            database.Commit();
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(database.Orders.GetAll());
        }
    }
}
