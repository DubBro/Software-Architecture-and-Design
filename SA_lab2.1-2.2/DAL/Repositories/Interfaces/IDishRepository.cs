using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    public interface IDishRepository : IRepository<Dish>
    {
        IEnumerable<Dish> GetByCategory(string category);
        IEnumerable<Dish> GetByDay(int day);
    }
}
