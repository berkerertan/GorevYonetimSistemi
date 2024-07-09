using GorevYonetimSistemi.Data.Abstracts;
using GorevYonetimSistemi.Data.Concretes.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Data.Repositories
{
    public class TaskRepository : AsyncRepository<Entities.Concretes.Task>, ITaskRepository
    {
        public TaskRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
