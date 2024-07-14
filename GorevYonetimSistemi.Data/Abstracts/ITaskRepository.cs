using GorevYonetimSistemi.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Data.Abstracts
{
    public interface IToDoTaskRepository : IAsyncRepository<ToDoTask>
    {
    }
}
