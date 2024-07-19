using AutoMapper;
using GorevYonetimSistemi.Business.Abstracts;
using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Data.Abstracts;
using GorevYonetimSistemi.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Business.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>>(users);
        }

        public async Task<User?> GetAsync(Expression<Func<User, bool>> predicate, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            return await _userRepository.GetAsync(predicate, enableTracking, cancellationToken);

        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<User>(user);
        }

        public async Task UpdateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

    }
}
