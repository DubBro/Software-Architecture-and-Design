using BLL.Business.Interfaces;
using BLL.DTOs;
using DAL.UoW.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using DAL.Models;
using System;
using DAL.UoW.Services;

namespace BLL.Business.Services
{
    public class DeliveryService : IDeliveryService
    {
        private IUnitOfWorkDeliveryContext database;
        private IMapper mapper;

        public DeliveryService()
        {
            database = new UnitOfWorkDeliveryContext();
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Dish, DishDTO>().ReverseMap();
                cfg.CreateMap<Order, OrderDTO>().ReverseMap();
            });
            mapper = new Mapper(configMapper);
        }

        public void AddOrder(OrderDTO order)
        {
            database.Orders.Add(mapper.Map<OrderDTO, Order>(order));
            database.Commit();
        }

        public IEnumerable<DishDTO> GetComplex()
        {
            List<DishDTO> complex = new List<DishDTO>();

            foreach (var category in Category.All)
            {
                IEnumerable<DishDTO> dishes = GetMenuByCategory(category);

                foreach (var dish in dishes)
                {
                    if (dish.Days.Length == 7)
                    {
                        complex.Add(dish);
                        break;
                    }
                }
            }

            return complex;
        }

        public DishDTO GetDish(int id)
        {
            DishDTO dish = mapper.Map<Dish, DishDTO>(database.Dishes.Get(id));

            if (dish == null)
            {
                throw new Exception("ERROR: Invalid ID");
            }

            return dish;
        }

        public IEnumerable<DishDTO> GetMenu()
        {
            return mapper.Map<IEnumerable<Dish>, IEnumerable<DishDTO>>(database.Dishes.GetAll());
        }

        public IEnumerable<DishDTO> GetMenuByCategory(string category)
        {
            foreach (var cat in Category.All)
            {
                if (category.ToLower() == cat)
                {
                    return mapper.Map<IEnumerable<Dish>, IEnumerable<DishDTO>>(database.Dishes.GetByCategory(category.ToLower()));
                }
            }

            throw new Exception("ERROR: Invalid category");
        }

        public IEnumerable<DishDTO> GetMenuByDay(int day)
        {
            if (day < 1 || day > 7)
            {
                throw new Exception("ERROR: Invalid day");
            }

            return mapper.Map<IEnumerable<Dish>, IEnumerable<DishDTO>>(database.Dishes.GetByDay(day));
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(database.Orders.GetAll());
        }
    }
}
