using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        private DeliveryContext context;

        public DishRepository(DeliveryContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Dish> GetByCategory(string category)
        {
            return context.Dishes.Where(d => d.Category == category).ToList();
        }

        public IEnumerable<Dish> GetByDay(int day)
        {
            IEnumerable<Dish> dishesToReturn = new List<Dish>();

            var dishes = GetAll();

            foreach (var dish in dishes)
            {
                for (int i = 0; i < dish.Days.Length; i++)
                {
                    if (day == dish.Days[i])
                    {
                        dishesToReturn = dishesToReturn.Append(dish);
                        break;
                    }
                }
            }

            return dishesToReturn;
        }
    }
}
