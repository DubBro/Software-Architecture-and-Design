using AutoMapper;
using BLL.DTOs;
using WebAPI.Models;

namespace WebAPI.App_Start
{
    public class AutoMapperConfig
    {
        public static Mapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DishDTO, DishViewModel>().ReverseMap();
                cfg.CreateMap<OrderDTO, OrderViewModel>().ReverseMap();
            });

            return new Mapper(config);
        }
    }
}