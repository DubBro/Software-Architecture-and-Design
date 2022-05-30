using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
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
