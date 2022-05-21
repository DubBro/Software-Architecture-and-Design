using BLL.DTOs;
using System.Collections.Generic;

namespace BLL.Business.Interfaces
{
    public interface IDeliveryService
    {
        IEnumerable<DishDTO> GetMenuByDay(int day);
        IEnumerable<DishDTO> GetMenuByCategory(string category);
        IEnumerable<DishDTO> GetMenu();
        DishDTO GetDish(int id);
        IEnumerable<DishDTO> GetComplex();
        void AddOrder(OrderDTO order);
        IEnumerable<OrderDTO> GetOrders();
    }
}