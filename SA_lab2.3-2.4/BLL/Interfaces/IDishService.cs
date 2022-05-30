using BLL.DTOs;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IDishService
    {
        IEnumerable<DishDTO> GetMenuByDay(int day);
        IEnumerable<DishDTO> GetMenuByCategory(string category);
        IEnumerable<DishDTO> GetMenu();
        DishDTO GetDish(int id);
        IEnumerable<DishDTO> GetComplex();
    }
}
