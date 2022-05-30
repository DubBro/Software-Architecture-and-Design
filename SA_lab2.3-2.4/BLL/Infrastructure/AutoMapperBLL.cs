using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Infrastructure
{
    public class AutoMapperBLL
    {
        public static Mapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Dish, DishDTO>().ReverseMap();
                cfg.CreateMap<Order, OrderDTO>().ReverseMap();
            });

            return new Mapper(config);
        }
    }
}
