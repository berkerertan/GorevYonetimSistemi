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
    public class ToDoTaskRepository : AsyncRepository<ToDoTask>, IToDoTaskRepository
    {
        public ToDoTaskRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
