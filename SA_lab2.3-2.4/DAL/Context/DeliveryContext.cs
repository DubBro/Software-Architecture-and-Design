using DAL.Entities;
using System.Data.Entity;

namespace DAL.Context
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext()
        {
            new DropCreateDeliveryDatabaseAlways().InitializeDatabase(this);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }
}
