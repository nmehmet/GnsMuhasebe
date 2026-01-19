using GnsMuhasebe.domain.Entities;
using System.Linq.Expressions;

namespace GnsMuhasebe.Application.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        /// <summary>
        /// Get item from <typeparamref name="T"/> by id.
        /// </summary>
        /// <param name="id">id of spesified item.</param>
        /// <returns>one item from <typeparamref name="T"/> table.</returns>
        Task<T?> GetByIdAsync(int id);
        /// <summary>
        /// Get all itmes from <typeparamref name="T"/> table.
        /// </summary>
        /// <returns>All items from <typeparamref name="T"/> table.</returns>
        Task<List<T>> GetAllAsync();
        /// <summary>
        /// Get items from <typeparamref name="T"/> table by predicate.
        /// </summary>
        /// <param name="predicate">Specified Expression</param>
        /// <returns>Gets items that applies specified expression from <typeparamref name="T"/> table.</returns>
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Adds new item to <typeparamref name="T"/> table.
        /// </summary>
        /// <param name="entity">Item to adding <typeparamref name="T"/> table.</param>
        /// <returns></returns>
        Task<int> AddAsync(T entity);
        /// <summary>
        /// Updates item in <typeparamref name="T"/> table.
        /// </summary>
        /// <param name="entity">Item that wanted to be updated.</param>
        void Update(T entity);
        /// <summary>
        /// Deletes item from <typeparamref name="T"/> table.
        /// </summary>
        /// <param name="entity">Item that wanted to be deleted.</param>
        void Delete(T entity);

        Task<int> SaveChangesAsync();
    }
}
