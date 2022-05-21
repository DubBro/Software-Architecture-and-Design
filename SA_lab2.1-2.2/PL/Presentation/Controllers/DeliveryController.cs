using BLL.Business.Interfaces;
using BLL.Business.Services;
using PL.Presentation.Interfaces;
using PL.ViewModels;
using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.DTOs;

namespace PL.Presentation.Controllers
{
    public class DeliveryController : IDeliveryController
    {
        private IDeliveryService service;
        private Mapper mapper;

        public DeliveryController()
        {
            service = new DeliveryService();
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DishDTO, DishViewModel>().ReverseMap();
                cfg.CreateMap<OrderDTO, OrderViewModel>().ReverseMap();
            });
            mapper = new Mapper(configMapper);
        }

        public void CreateOrder()
        {
            Console.Write("Enter description of the order: ");
            string details = Console.ReadLine();

            List<DishViewModel> dishes = new List<DishViewModel>();
            try
            {
                for (; ; )
                {
                    Console.WriteLine("Enter number of a meal or enter 0 to finish the selection and create order: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    if (id != 0)
                    {
                        dishes.Add(mapper.Map<DishDTO, DishViewModel>(service.GetDish(id)));
                    }
                    else
                    {
                        break;
                    }
                }

                OrderViewModel order = new OrderViewModel { Details = details, Dishes = dishes };
                service.AddOrder(mapper.Map<OrderViewModel, OrderDTO>(order));
                Console.WriteLine("Order has been created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateOrderComplex()
        {
            try
            {
                Console.Write("Enter description of the order: ");
                string details = Console.ReadLine();
                List<DishViewModel> dishes = mapper.Map<IEnumerable<DishDTO>, List<DishViewModel>>(service.GetComplex());

                OrderViewModel order = new OrderViewModel { Details = details, Dishes = dishes };
                service.AddOrder(mapper.Map<OrderViewModel, OrderDTO>(order));
                Console.WriteLine("Order has been created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowComplex()
        {
            try
            {
                List<DishViewModel> menu = mapper.Map<IEnumerable<DishDTO>, List<DishViewModel>>(service.GetComplex());
                ShowDishes(menu);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowMenu()
        {
            try
            {
                List<DishViewModel> menu = mapper.Map<IEnumerable<DishDTO>, List<DishViewModel>>(service.GetMenu());
                ShowDishes(menu);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowMenuByCategory()
        {
            Console.Write("Enter the category: ");
            string category = Console.ReadLine();

            try
            {
                List<DishViewModel> dishes = mapper.Map<IEnumerable<DishDTO>, List<DishViewModel>>(service.GetMenuByCategory(category));
                ShowDishes(dishes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowMenuByDay()
        {
            Console.Write("Enter a number of the day (1-Monday, 7-Sunday): ");
            try
            {
                int day = Convert.ToInt32(Console.ReadLine());
                List<DishViewModel> dishes = mapper.Map<IEnumerable<DishDTO>, List<DishViewModel>>(service.GetMenuByDay(day));
                ShowDishes(dishes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowOrders()
        {
            try
            {
                List<OrderViewModel> orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderViewModel>>(service.GetOrders());

                foreach (var order in orders)
                {
                    Console.Write("{0} - Description: {1}; Dishes: ", order.ID, order.Details);
                    foreach (var dish in (List<DishViewModel>)order.Dishes)
                    {
                        Console.Write(dish.Name + ", ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowDishes(List<DishViewModel> dishes)
        {
            foreach (var item in dishes)
            {
                Console.WriteLine("{0} - {1} (category: {2});", item.ID, item.Name, item.Category);
            }
        }
    }
}
