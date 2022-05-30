using BLL.DTOs;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(OrderDTO order);
        IEnumerable<OrderDTO> GetOrders();
    }
}
