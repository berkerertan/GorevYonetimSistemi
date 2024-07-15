using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Business.Abstracts
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterDto registerDto);
        Task<AccessToken> Login(LoginDto loginDto);
    }
}
