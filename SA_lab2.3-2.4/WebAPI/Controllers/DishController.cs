using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPI.App_Start;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DishController : ApiController
    {
        private IDishService service;
        private IMapper mapper;

        public DishController(IDishService service)
        {
            this.service = service;
            mapper = AutoMapperConfig.InitializeAutoMapper();
        }

        [HttpGet]
        [Route("api/menu/complex")]
        public IHttpActionResult GetComplex()
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<DishDTO>, IEnumerable<DishViewModel>>(service.GetComplex()));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/menu")]
        public IHttpActionResult GetMenu()
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<DishDTO>, IEnumerable<DishViewModel>>(service.GetMenu()));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/menu")]
        public IHttpActionResult GetMenuByCategory(string category)
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<DishDTO>, IEnumerable<DishViewModel>>(service.GetMenuByCategory(category)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/menu")]
        public IHttpActionResult GetMenuByDay(int day)
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<DishDTO>, IEnumerable<DishViewModel>>(service.GetMenuByDay(day)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}