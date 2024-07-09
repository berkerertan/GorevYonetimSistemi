using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Entities.Abstracts
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
