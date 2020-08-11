using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using TicketStore.Server.Contracts;
using TicketStore.Server.Entities;

namespace TicketStore.Server.DataAccess
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _ctx;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _ctx = repositoryContext;
        }

        public void Create(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return _ctx.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _ctx.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            _ctx.Set<T>().Update(entity);
        }
    }
}
