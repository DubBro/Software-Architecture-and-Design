using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Services
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private DeliveryContext context;

        public OrderRepository(DeliveryContext context) : base(context)
        {
            this.context = context;
        }
    }
}
