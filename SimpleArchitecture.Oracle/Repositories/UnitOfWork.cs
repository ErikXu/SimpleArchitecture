using System;
using System.Data.Entity;
using SimpleArchitecture.Domain.Repositories;

namespace SimpleArchitecture.Oracle.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;
        private DbContextTransaction _transaction;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public IDisposable BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
            return _transaction;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}