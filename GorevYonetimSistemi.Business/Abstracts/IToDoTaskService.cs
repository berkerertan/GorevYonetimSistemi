using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Business.Abstracts
{
    public interface IToDoTaskService
    {
        Task<IEnumerable<ToDoTask>> GetAllAsync();
        Task<IEnumerable<ToDoTask>> GetByStatusAsync(string status);
        Task<ToDoTask> GetByIdAsync(int id);
        Task AddAsync(ToDoTask taskDto);
        Task UpdateAsync(ToDoTask taskDto);
        Task DeleteAsync(int id);
    }
}
