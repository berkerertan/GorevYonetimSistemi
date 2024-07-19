using GorevYonetimSistemi.Business.Abstracts;
using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Business.Rules;
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
        private readonly ITokenHelper _tokenHelper;
        private readonly UserBusinessRules _rules;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, UserBusinessRules rules)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _rules = rules;
        }

        public async Task<AccessToken> Login(LoginDto loginDto)
        {
            User? user = await _userService.GetAsync(predicate: u => u.Username == loginDto.Username);
            _rules.UserExists(user);
            _rules.PasswordMatch(user.Password, loginDto.Password);

            //if (!HashingHelper.VerifyPasswordHash(loginDto.Password, user.Password))
            //{
            //    throw new Exception("Şifre eşleşmiyor");
            //}

            var accessToken = _tokenHelper.CreateToken(user);
            return accessToken;
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            var userExists = await _userService.GetAsync(predicate: u => u.Username == registerDto.Username);
            _rules.UserNotExists(userExists);

            //HashingHelper.CreatePasswordHash(registerDto.Password, out byte[] passwordHash);

            var user = new UserDto
            {
                Username = registerDto.Username,
                Password = registerDto.Password
            };
            await _userService.AddAsync(user);

            return true;

        }

    }
}
