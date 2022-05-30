using BLL.DTOs;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class DishService : Service, IDishService
    {
        public DishService(IUnitOfWork database) : base(database)
        {
        }

        public IEnumerable<DishDTO> GetComplex()
        {
            IEnumerable<DishDTO> complex = new List<DishDTO>();

            foreach (var category in Category.All)
            {
                IEnumerable<DishDTO> dishes = GetMenuByCategory(category);

                foreach (var dish in dishes)
                {
                    if (dish.Days.Length == 7)
                    {
                        complex = complex.Append(dish);
                        break;
                    }
                }
            }

            return complex;
        }

        public DishDTO GetDish(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            DishDTO dish = mapper.Map<Dish, DishDTO>(database.Dishes.Get(id));

            if (dish == null)
            {
                throw new InvalidIdException();
            }

            return dish;
        }

        public IEnumerable<DishDTO> GetMenu()
        {
            return mapper.Map<IEnumerable<Dish>, IEnumerable<DishDTO>>(database.Dishes.GetAll());
        }

        public IEnumerable<DishDTO> GetMenuByCategory(string category)
        {
            IEnumerable<DishDTO> dishes = mapper.Map<IEnumerable<Dish>, IEnumerable<DishDTO>>(database.Dishes.GetByCategory(category.ToLower()));

            if (dishes.ToList().Count == 0)
            {
                throw new InvalidCategoryException();
            }

            return dishes;
        }

        public IEnumerable<DishDTO> GetMenuByDay(int day)
        {
            if (day < 1 || day > 7)
            {
                throw new InvalidDayException();
            }

            return mapper.Map<IEnumerable<Dish>, IEnumerable<DishDTO>>(database.Dishes.GetByDay(day));
        }
    }
}
