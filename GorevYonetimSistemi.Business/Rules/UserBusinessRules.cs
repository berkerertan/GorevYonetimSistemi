using GorevYonetimSistemi.Business.Constants;
using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Core.CrossCuttingConcerns;
using GorevYonetimSistemi.Data.Abstracts;
using GorevYonetimSistemi.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Business.Rules
{
    public class UserBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void UserExists(User user)
        {
            if (user == null)
            {
                throw new Exception(Messages.UserNotFound);
            }
        }
        public void UserNotExists(User user)
        {
            if (user != null)
            {
                throw new Exception(Messages.AlreadyExist);

            }

        }

        public void PasswordMatch(string passwordDb,string passwordDto)
        {
            if (passwordDb != passwordDto)
            {
                throw new Exception("şifre eşleşmiyor");
            }
        }


        public async Task UsernameShouldBeNotExists(string username)
        {
            User? user = await _userRepository.GetAsync(u => u.Username == username);
            if (user is not null) throw new Exception("Username already exists");
        }
    }
}
