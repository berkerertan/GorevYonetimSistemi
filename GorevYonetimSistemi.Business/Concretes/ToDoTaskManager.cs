using AutoMapper;
using GorevYonetimSistemi.Business.Abstracts;
using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Data.Abstracts;
using GorevYonetimSistemi.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Business.Concretes
{
    public class ToDoTaskManager : IToDoTaskService
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly IMapper _mapper;
        public ToDoTaskManager(IToDoTaskRepository toDoTaskRepository, IMapper mapper)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _mapper = mapper;
        }
        public async Task AddToDoTaskAsync(ToDoTaskDto taskDto)
        {
            var task = _mapper.Map<ToDoTask>(taskDto);
            await _toDoTaskRepository.AddAsync(task);
            await _toDoTaskRepository.SaveChangesAsync();
        }

        public async Task DeleteToDoTaskAsync(int id)
        {
            var task = await _toDoTaskRepository.GetByIdAsync(id);
            _toDoTaskRepository.Delete(task);
            await _toDoTaskRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDoTaskDto>> GetAllToDoTasksAsync()
        {
            var tasks = await _toDoTaskRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ToDoTaskDto>>(tasks);
        }

        public async Task<ToDoTaskDto> GetToDoTaskByIdAsync(int id)
        {
            var task = await _toDoTaskRepository.GetByIdAsync(id);
            return _mapper.Map<ToDoTaskDto>(task);
        }

        public async Task<IEnumerable<ToDoTaskDto>> GetToDoTasksByStatusAsync(string status)
        {
            var tasks = status;//await _toDoTaskRepository.FindAsync(t => t.Status == status);
            return _mapper.Map<IEnumerable<ToDoTaskDto>>(tasks);
        }

        public async Task UpdateToDoTaskAsync(ToDoTaskDto taskDto)
        {
            var task = _mapper.Map<ToDoTask>(taskDto);
            _toDoTaskRepository.Update(task);
            await _toDoTaskRepository.SaveChangesAsync();
        }
    }
}
