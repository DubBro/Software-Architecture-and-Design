using DAL.Models;
using System.Data.Entity;

namespace DAL.Context
{
    internal class DropCreateDeliveryDatabaseAlways : DropCreateDatabaseAlways<DeliveryContext>
    {
        protected override void Seed(DeliveryContext context)
        {
            Dish soup = new Dish { Name = "Soup", Category = "main", Days = new int[] { (int)Week.Monday, (int)Week.Tuesday, (int)Week.Wednesday, (int)Week.Thursday, (int)Week.Friday, (int)Week.Saturday, (int)Week.Sunday } };
            Dish borsch = new Dish { Name = "Borsch", Category = "main", Days = new int[] { (int)Week.Monday, (int)Week.Wednesday, (int)Week.Friday, (int)Week.Sunday } };
            Dish juice = new Dish { Name = "Juice", Category = "drink", Days = new int[] { (int)Week.Monday, (int)Week.Tuesday, (int)Week.Wednesday, (int)Week.Thursday, (int)Week.Friday, (int)Week.Saturday, (int)Week.Sunday } };
            Dish coffee = new Dish { Name = "Coffee", Category = "drink", Days = new int[] { (int)Week.Monday, (int)Week.Tuesday, (int)Week.Thursday } };
            Dish tea = new Dish { Name = "Tea", Category = "drink", Days = new int[] { (int)Week.Monday, (int)Week.Wednesday, (int)Week.Sunday } };
            Dish burger = new Dish { Name = "Burger", Category = "snack", Days = new int[] { (int)Week.Friday, (int)Week.Saturday, (int)Week.Sunday } };
            Dish fries = new Dish { Name = "French fries", Category = "snack", Days = new int[] { (int)Week.Monday, (int)Week.Tuesday, (int)Week.Friday, (int)Week.Saturday, (int)Week.Sunday } };
            Dish pudding = new Dish { Name = "Pudding", Category = "dessert", Days = new int[] { (int)Week.Monday, (int)Week.Tuesday, (int)Week.Wednesday, (int)Week.Thursday, (int)Week.Friday, (int)Week.Saturday, (int)Week.Sunday } };
            Dish cake = new Dish { Name = "Cake", Category = "dessert", Days = new int[] { (int)Week.Thursday, (int)Week.Friday, (int)Week.Saturday, (int)Week.Sunday } };

            Dish[] dishes = new Dish[] { soup, borsch, juice, coffee, tea, burger, fries, pudding, cake };

            foreach (Dish dish in dishes)
            {
                context.Dishes.Add(dish);
            }

            context.SaveChanges();
        }
    }
}
