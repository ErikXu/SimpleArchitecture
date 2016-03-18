using System;

namespace SimpleArchitecture.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        IDisposable BeginTransaction();

        void Commit();

        void Rollback();
    }
}