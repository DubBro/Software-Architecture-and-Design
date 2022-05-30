using DAL.Context;
using DAL.Interfaces;
using System;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DeliveryContext context;

        private IOrderRepository orders;
        private IDishRepository dishes;

        private bool disposed;

        public UnitOfWork()
        {
            context = new DeliveryContext();
        }
        public IOrderRepository Orders
        {
            get
            {
                if (orders == null)
                {
                    orders = new OrderRepository(context);
                }
                return orders;
            }
        }

        public IDishRepository Dishes
        {
            get
            {
                if (dishes == null)
                {
                    dishes = new DishRepository(context);
                }
                return dishes;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
