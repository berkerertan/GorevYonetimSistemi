using GorevYonetimSistemi.Data.Abstracts;
using GorevYonetimSistemi.Data.Concretes.Contexts;
using GorevYonetimSistemi.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Data.Repositories
{
    public class UserRepository : AsyncRepository<User>,IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
