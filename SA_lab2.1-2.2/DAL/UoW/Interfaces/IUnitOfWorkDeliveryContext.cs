using DAL.Repositories.Interfaces;

namespace DAL.UoW.Interfaces
{
    public interface IUnitOfWorkDeliveryContext : IUnitOfWork
    {
        IOrderRepository Orders { get; }
        IDishRepository Dishes { get; }
    }
}
