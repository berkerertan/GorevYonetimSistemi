using GorevYonetimSistemi.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Business.Abstracts
{
    public interface IToDoTaskService
    {
        Task<IEnumerable<ToDoTaskDto>> GetAllToDoTasksAsync();
        Task<IEnumerable<ToDoTaskDto>> GetToDoTasksByStatusAsync(string status);
        Task<ToDoTaskDto> GetToDoTaskByIdAsync(int id);
        Task AddToDoTaskAsync(ToDoTaskDto taskDto);
        Task UpdateToDoTaskAsync(ToDoTaskDto taskDto);
        Task DeleteToDoTaskAsync(int id);
    }
}
