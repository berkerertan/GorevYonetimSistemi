using GorevYonetimSistemi.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Entities.Concretes
{
    public class User : BaseEntity<Guid>
    {
        public User()
        {
        }

        public User(string username, string password, int? roleId)
        {
            Username = username;
            Password = password;
            RoleId = roleId;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public ICollection<ToDoTask> ToDoTasks { get; set; }
    }
}
