using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using TicketStore.Server.Logic.DataAccess.Contracts;

namespace TicketStore.Server.Logic.DataAccess
{
    /// <summary>
    /// Base repository implementation.
    /// </summary>
    /// <typeparam name="T">Data type.</typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _ctx;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="repositoryContext">Repository context.</param>
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _ctx = repositoryContext;
        }

        /// <inheritdoc/>
        public void Create(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        /// <inheritdoc/>
        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
        }

        /// <inheritdoc/>
        public IQueryable<T> FindAll()
        {
            return _ctx.Set<T>().AsNoTracking();
        }

        /// <inheritdoc/>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _ctx.Set<T>().Where(expression).AsNoTracking();
        }

        /// <inheritdoc/>
        public void Update(T entity)
        {
            _ctx.Set<T>().Update(entity);
        }
    }
}
