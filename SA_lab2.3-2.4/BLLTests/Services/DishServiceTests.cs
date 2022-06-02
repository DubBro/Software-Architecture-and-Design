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
    public class DishServiceTests
    {
        private readonly IFixture fixture = new Fixture();

        private IDishService service;
        private IUnitOfWork uow;
        private IMapper mapper;

        [SetUp]
        protected void SetUp()
        {
            uow = Substitute.For<IUnitOfWork>();
            fixture.Inject(uow);

            mapper = AutoMapperBLL.InitializeAutoMapper();

            service = fixture.Create<DishService>();
        }

        [Test]
        public void GetComplex_should_call_dish_repository_get_by_category_method_for_each_category()
        {
            // Arrange
            IEnumerable<Dish> dishes = fixture.Create<IEnumerable<Dish>>();
            uow.Dishes.GetByCategory(Arg.Any<string>()).Returns(dishes);

            // Act
            service.GetComplex();

            // Assert
            uow.Dishes.Received(Category.All.Length).GetByCategory(Arg.Any<string>());
        }

        [Test]
        public void GetComplex_should_return_IEnumerable_DishDTO()
        {
            // Arrange
            IEnumerable<Dish> dishes = fixture.Create<IEnumerable<Dish>>();
            uow.Dishes.GetByCategory(Arg.Any<string>()).Returns(dishes);
            var dishDTOs = mapper.Map<IEnumerable<Dish>, IEnumerable<DishDTO>>(dishes);

            // Act
            IEnumerable<DishDTO> testDishDTOs = service.GetComplex();

            // Assert
            Assert.IsTrue(testDishDTOs.GetType() == dishDTOs.GetType());
        }

        [Test]
        public void GetDish_should_return_exception_if_id_is_less_or_equals_0()
        {
            // Arrange
            int invalidId = -fixture.Create<int>(); ;

            // Act and assert
            Assert.Throws<InvalidIdException>(delegate { service.GetDish(invalidId); });
        }

        [Test]
        public void GetDish_should_return_exception_if_dish_equals_null()
        {
            // Arrange
            int id = fixture.Create<int>();
            uow.Dishes.Get(id).Returns((Dish)null);

            // Act and assert
            Assert.Throws<InvalidIdException>(delegate { service.GetDish(id); });
        }

        [Test]
        public void GetDish_should_return_DishDTO()
        {
            // Arrange
            int id = fixture.Create<int>();
            Dish dish = fixture.Create<Dish>();
            DishDTO dishDTO = mapper.Map<Dish, DishDTO>(dish);
            uow.Dishes.Get(id).Returns(dish);

            // Act
            var testDishDTO = service.GetDish(id);

            //Assert
            Assert.IsTrue(testDishDTO.GetType() == dishDTO.GetType());
        }

        [Test]
        public void GetDish_should_call_dish_repository_get_method_once()
        {
            // Arrange
            int id = fixture.Create<int>();

            // Act
            service.GetDish(id);

            // Assert
            uow.Dishes.Received(1).Get(Arg.Any<int>());
        }

        [Test]
        public void GetMenu_should_return_IEnumerable_DishDTO()
        {
            // Arrange
            IEnumerable<Dish> dishes = fixture.Create<IEnumerable<Dish>>();
            IEnumerable<DishDTO> dishDTOs = mapper.Map<IEnumerable<Dish>, IEnumerable<DishDTO>>(dishes);
            uow.Dishes.GetAll().Returns(dishes);

            // Act
            var testDishDTOs = service.GetMenu();

            // Assert
            Assert.IsTrue(testDishDTOs.GetType() == dishDTOs.GetType());
        }

        [Test]
        public void GetMenu_should_call_dish_repository_get_all_method_once()
        {
            // Arrange
            IEnumerable<Dish> dishes = fixture.Create<IEnumerable<Dish>>();
            uow.Dishes.GetAll().Returns(dishes);

            // Act
            service.GetMenu();

            // Assert
            uow.Dishes.Received(1).GetAll();
        }

        [Test]
        public void GetMenuByCategory_should_return_exception_if_category_is_invalid()
        {
            // Arrange
            string category = fixture.Create<string>();
            uow.Dishes.GetByCategory(category).Returns((IEnumerable<Dish>)null);

            // Act and assert
            Assert.Throws<InvalidCategoryException>(delegate { service.GetMenuByCategory(category); });
        }

        [Test]
        public void GetMenuByCategory_should_call_dish_repository_get_by_category_method_once()
        {
            // Arrange
            string category = fixture.Create<string>();
            IEnumerable<Dish> dishes = fixture.Create<IEnumerable<Dish>>();
            uow.Dishes.GetByCategory(category).Returns(dishes);

            // Act
            service.GetMenuByCategory(category);

            // Assert
            uow.Dishes.Received(1).GetByCategory(category);
        }

        [Test]
        public void GetMenuByCategory_should_return_IEnumerable_DishDTO()
        {
            // Arrange
            string category = fixture.Create<string>();
            IEnumerable<Dish> dishes = fixture.Create<IEnumerable<Dish>>();
            IEnumerable<DishDTO> dishDTOs = mapper.Map<IEnumerable<Dish>, IEnumerable<DishDTO>>(dishes);
            uow.Dishes.GetByCategory(category).Returns(dishes);

            // Act
            var testDishDTOs = service.GetMenuByCategory(category);

            // Assert
            Assert.IsTrue(testDishDTOs.GetType() == dishDTOs.GetType());
        }

        [Test]
        public void GetMenuByDay_should_return_exception_if_day_is_less_than_1()
        {
            // Arrange
            int day = 0;

            // Act and assert
            Assert.Throws<InvalidDayException>(delegate { service.GetMenuByDay(day); });
        }

        [Test]
        public void GetMenuByDay_should_return_exception_if_day_is_more_than_7()
        {
            // Arrange
            int day = 8;

            // Act and assert
            Assert.Throws<InvalidDayException>(delegate { service.GetMenuByDay(day); });
        }

        [Test]
        public void GetMenuByDay_should_call_dish_repository_get_by_day_method_once()
        {
            // Arrange
            int day = 1;

            // Act
            service.GetMenuByDay(day);

            // Assert
            uow.Dishes.Received(1).GetByDay(day);
        }

        [Test]
        public void GetMenuByDay_should_return_IEnumerable_DishDTO()
        {
            // Arrange
            int day = 1;
            IEnumerable<Dish> dishes = fixture.Create<IEnumerable<Dish>>();
            IEnumerable<DishDTO> dishDTOs = mapper.Map<IEnumerable<Dish>, IEnumerable<DishDTO>>(dishes);
            uow.Dishes.GetByDay(day).Returns(dishes);

            // Act
            var testDishDTOs = service.GetMenuByDay(day);

            // Assert
            Assert.IsTrue(testDishDTOs.GetType() == dishDTOs.GetType());
        }
    }
}