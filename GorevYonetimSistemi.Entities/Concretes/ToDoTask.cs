using GorevYonetimSistemi.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Entities.Concretes
{
    public class ToDoTask : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "new";
        public Guid UserId { get; set; }
        public User User { get; set; }
    }

    public enum TaskStatus
    {
        New,
        InProgress,
        Completed
    }
}
