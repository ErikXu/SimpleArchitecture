using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SimpleArchitecture.Domain.Repositories;

namespace SimpleArchitecture.Oracle.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;

        protected GenericRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<TEntity> AsQueryable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            var query = DbContext.Set<TEntity>().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return orderBy != null ? orderBy(query) : query;
        }

        public TEntity GetById(object id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }
    }
}