using System;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IDishRepository Dishes { get; }

        void Commit();
    }
}
