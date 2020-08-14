using System;
using System.Linq;
using System.Linq.Expressions;

namespace TicketStore.Server.Contracts
{
    /// <summary>
    /// Base repository.
    /// </summary>
    /// <typeparam name="T">Data type.</typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Finds all entities.
        /// </summary>
        /// <returns>All entities.</returns>
        IQueryable<T> FindAll();

        /// <summary>
        /// Finds entities by condition.
        /// </summary>
        /// <param name="expression">Condition expression.</param>
        /// <returns>All matching entities.</returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Creates an entitiy.
        /// </summary>
        /// <param name="entity">Entity to be created.</param>
        void Create(T entity);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">Entity to be updated.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes an entitiy.
        /// </summary>
        /// <param name="entity">Entity to be deleted.</param>
        void Delete(T entity);
    }
}
