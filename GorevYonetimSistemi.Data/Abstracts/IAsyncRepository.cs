using GorevYonetimSistemi.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Data.Abstracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T?> GetAsync(
            Expression<Func<T, bool>> predicate,
            bool enableTracking = true,
            CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
