using GorevYonetimSistemi.Business.Abstracts;
using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Core.Utilities.Security.Hashing;
using GorevYonetimSistemi.Core.Utilities.Security.JWT;
using GorevYonetimSistemi.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
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

        public AuthManager(IConfiguration configuration, IUserService userService, ITokenHelper tokenHelper)
        {
            _configuration = configuration;
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> Login(LoginDto loginDto)
        {
            User? user = await _userService.GetAsync(predicate: u => u.Username == loginDto.Username);

            if (user == null)
            {
                throw new Exception("kullanıcı bulunmadı");
            }

            if (user.Password != loginDto.Password)
            {
                throw new Exception("şifre eşleşmiyor");
            }

            //if (!HashingHelper.VerifyPasswordHash(loginDto.Password, user.Password))
            //{
            //    throw new Exception("Password is incorrect");
            //}

            var accessToken = _tokenHelper.CreateToken(user);
            return accessToken;
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            var userExists = await _userService.GetAsync(predicate: u => u.Username == registerDto.Username);

            if (userExists != null)
            {
                return false;
            }

            //HashingHelper.CreatePasswordHash(registerDto.Password, out byte[] passwordHash);

            var user = new User
            {
                Username = registerDto.Username,
                Password = registerDto.Password
            };
            await _userService.AddAsync(user);

            return true;

        }

    }
}
