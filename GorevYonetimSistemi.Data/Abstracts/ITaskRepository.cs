using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Data.Abstracts
{
    public interface ITaskRepository : IAsyncRepository<Entities.Concretes.Task>
    {
    }
}
