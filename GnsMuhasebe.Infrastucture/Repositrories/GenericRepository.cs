using GnsMuhasebe.Application.Interfaces;
using GnsMuhasebe.domain.Entities;
using GnsMuhasebe.Infrastucture.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GnsMuhasebe.Infrastucture.Repositrories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            DateTime now = DateTime.Now;
            entity.CreatedOn = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            entity.UpdatedOn = DateTime.UtcNow;
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
