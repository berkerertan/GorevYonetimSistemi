using GorevYonetimSistemi.Data.Abstracts;
using GorevYonetimSistemi.Data.Concretes.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Data.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly BaseDbContext _context;

        public AsyncRepository(BaseDbContext context)
        {
            _context = context;
        }
        public async Task<T?> GetAsync(
            Expression<Func<T, bool>> predicate,
            bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _context.Set<T>();

            if (!enableTracking)
            {
                query = query.AsNoTracking();
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return null;//await _context.Where(predicate).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _context.Set<T>();

            if (!enableTracking)
            {
                query = query.AsNoTracking();
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync(cancellationToken);
        }
    }

}
