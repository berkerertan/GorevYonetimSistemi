using GorevYonetimSistemi.Business.Abstracts;
using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Core.Utilities.Security.Hashing;
using GorevYonetimSistemi.Core.Utilities.Security.JWT;
using GorevYonetimSistemi.Entities.Concretes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<AccessToken> Login(LoginDto loginDto)
        {
            User? user = await _userService.GetAsync(predicate: u => u.Username == loginDto.Username);

            if (user == null || !HashingHelper.VerifyPasswordHash(loginDto.Password, user.Password))
            {
                return null;
            }

            return _tokenHelper.CreateToken(user);
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            var userExists = await _userService.GetAsync(predicate: u => u.Username == registerDto.Username);

            if (userExists != null)
            {
                return false;
            }

            byte[] passwordHash = HashingHelper.CreatePasswordHash(registerDto.Password);

            var user = new User
            {
                Username = registerDto.Username,
                Password = passwordHash
            };
            await _userService.AddAsync(user);

            return true;

        }

    }
}
