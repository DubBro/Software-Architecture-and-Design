using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.App_Start;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class OrderController : ApiController
    {
        private IOrderService orderService;
        private IDishService dishService;
        private IMapper mapper;

        public OrderController(IOrderService orderService, IDishService dishService)
        {
            this.orderService = orderService;
            this.dishService = dishService;
            mapper = AutoMapperConfig.InitializeAutoMapper();
        }

        [HttpPost]
        [Route("api/order")]
        public IHttpActionResult PostOrder([FromBody] OrderViewModel order)
        {
            try
            {
                List<DishViewModel> dishes = new List<DishViewModel>();

                int i = 0;
                foreach (var dish in order.Dishes)
                {
                    int id = order.Dishes.ToList()[i].ID;
                    dishes.Add(mapper.Map<DishDTO, DishViewModel>(dishService.GetDish(id)));
                    i++;
                }

                order.Dishes = dishes;
                orderService.AddOrder(mapper.Map<OrderViewModel, OrderDTO>(order));
                return GetOrders();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/order/complex")]
        public IHttpActionResult PostOrderComplex([FromBody] OrderViewModel order)
        {
            try
            {
                IEnumerable<DishViewModel> dishes = mapper.Map<IEnumerable<DishDTO>, IEnumerable<DishViewModel>>(dishService.GetComplex());
                order.Dishes = dishes;
                orderService.AddOrder(mapper.Map<OrderViewModel, OrderDTO>(order));
                return GetOrders();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/orders")]
        public IHttpActionResult GetOrders()
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<OrderDTO>, IEnumerable<OrderViewModel>>(orderService.GetOrders()));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}