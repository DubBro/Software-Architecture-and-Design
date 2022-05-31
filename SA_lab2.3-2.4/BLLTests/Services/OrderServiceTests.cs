using NUnit.Framework;
using System.Collections.Generic;
using AutoFixture;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using NSubstitute;
using BLL.Infrastructure;
using BLL.DTOs;
using DAL.Entities;
using BLL.Exceptions;

namespace BLL.Services.Tests
{
    [TestFixture]
    public class OrderServiceTests
    {
        private readonly IFixture fixture = new Fixture();

        private IOrderService service;
        private IUnitOfWork uow;
        private IMapper mapper;

        [SetUp]
        protected void SetUp()
        {
            uow = Substitute.For<IUnitOfWork>();
            fixture.Inject(uow);

            mapper = AutoMapperBLL.InitializeAutoMapper();

            service = fixture.Create<OrderService>();
        }

        [Test]
        public void AddOrder_should_return_exception_if_order_equals_null()
        {
            // Arrange
            OrderDTO order = null;

            // Act and assert
            Assert.Throws<InvalidOrderException>(delegate { service.AddOrder(order); });
        }

        [Test]
        public void AddOrder_should_return_exception_if_order_dishes_count_is_0()
        {
            // Arrange
            IEnumerable<DishDTO> dishes = new List<DishDTO>();
            OrderDTO order = new OrderDTO { Details = fixture.Create<string>(), Dishes = dishes };

            // Act and assert
            Assert.Throws<InvalidOrderException>(delegate { service.AddOrder(order); });
        }

        [Test]
        public void AddOrder_should_call_order_repository_add_method_once()
        {
            // Arrange
            OrderDTO order = fixture.Create<OrderDTO>();

            // Act
            service.AddOrder(order);

            // Assert
            uow.Orders.Received(1).Add(Arg.Any<Order>());
        }

        [Test]
        public void AddOrder_should_call_unit_of_work_commit_method_once()
        {
            // Arrange
            OrderDTO order = fixture.Create<OrderDTO>();

            // Act
            service.AddOrder(order);

            // Assert
            uow.Received(1).Commit();
        }

        [Test]
        public void GetOrders_should_return_IEnumerable_OrderDTO()
        {
            // Arrange
            IEnumerable<Order> orders = fixture.Create<IEnumerable<Order>>();
            IEnumerable<OrderDTO> orderDTOs = mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(orders);
            uow.Orders.GetAll().Returns(orders);

            // Act
            var testOrderDTOs = service.GetOrders();

            // Assert
            Assert.IsTrue(testOrderDTOs.GetType() == orderDTOs.GetType());
        }

        [Test]
        public void GetOrders_should_call_order_repository_get_all_method_once()
        {
            // Arrange
            IEnumerable<Order> orders = fixture.Create<IEnumerable<Order>>();
            uow.Orders.GetAll().Returns(orders);

            // Act
            service.GetOrders();

            // Assert
            uow.Orders.Received(1).GetAll();
        }
        
        [Test]
        public void DeleteOrder_should_return_exception_if_id_is_less_or_equals_0()
        {
            // Arrange
            int id = -1;

            // Act and assert
            Assert.Throws<InvalidIdException>(delegate { service.DeleteOrder(id); });
        }

        [Test]
        public void DeleteOrder_should_call_order_repository_delete_method_once()
        {
            // Arrange
            var id = fixture.Create<int>();

            // Act
            service.DeleteOrder(id);

            // Assert
            uow.Orders.Received(1).Delete(id);
        }

        [Test]
        public void DeleteOrder_should_call_unit_of_work_commit_method_once()
        {
            // Arrange
            var id = fixture.Create<int>();

            // Act
            service.DeleteOrder(id);

            // Assert
            uow.Received(1).Commit();
        }

        [Test]
        public void UpdateOrder_should_return_exception_if_order_equals_null()
        {
            // Arrange
            OrderDTO order = null;

            // Act and assert
            Assert.Throws<InvalidOrderException>(delegate { service.UpdateOrder(order); });
        }

        [Test]
        public void UpdateOrder_should_return_exception_if_order_dishes_count_is_0()
        {
            // Arrange
            IEnumerable<DishDTO> dishes = new List<DishDTO>();
            OrderDTO order = new OrderDTO { Details = fixture.Create<string>(), Dishes = dishes };

            // Act and assert
            Assert.Throws<InvalidOrderException>(delegate { service.UpdateOrder(order); });
        }

        [Test]
        public void UpdateOrder_should_return_exception_if_order_not_exists_in_db()
        {
            // Arrange
            OrderDTO order = fixture.Create<OrderDTO>();
            uow.Orders.Get(order.ID).Returns((Order)null);

            // Act and assert
            Assert.Throws<InvalidIdException>(delegate { service.UpdateOrder(order); });
        }

        [Test]
        public void UpdateOrder_should_call_order_repository_update_method_once()
        {
            // Arrange
            OrderDTO order = fixture.Create<OrderDTO>();

            // Act
            service.UpdateOrder(order);

            // Assert
            uow.Orders.Received(1).Update(Arg.Any<Order>());
        }

        [Test]
        public void UpdateOrder_should_call_unit_of_work_commit_method_once()
        {
            // Arrange
            OrderDTO order = fixture.Create<OrderDTO>();

            // Act
            service.UpdateOrder(order);

            // Assert
            uow.Received(1).Commit();
        }

        [Test]
        public void UpdateOrder_should_call_order_repository_get_method_once()
        {
            // Arrange
            OrderDTO order = fixture.Create<OrderDTO>();

            // Act
            service.UpdateOrder(order);

            // Assert
            uow.Orders.Received(1).Get(Arg.Any<int>());
        }
    }
}