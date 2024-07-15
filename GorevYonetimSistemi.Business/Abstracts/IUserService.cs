using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Business.Abstracts
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetAsync(Expression<Func<User, bool>> predicate, bool enableTracking = true, CancellationToken cancellationToken = default);
        Task AddAsync(User userDto);
        Task UpdateAsync(User userDto);
        Task DeleteAsync(int id);
    }
}
