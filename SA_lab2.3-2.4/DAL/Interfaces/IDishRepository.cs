using DAL.Entities;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IDishRepository : IRepository<Dish>
    {
        IEnumerable<Dish> GetByCategory(string category);
        IEnumerable<Dish> GetByDay(int day);
    }
}
