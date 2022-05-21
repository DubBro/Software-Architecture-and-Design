using System;

namespace DAL.UoW.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
