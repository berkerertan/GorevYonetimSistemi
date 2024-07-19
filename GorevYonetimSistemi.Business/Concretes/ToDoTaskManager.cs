using AutoMapper;
using Azure.Core;
using GorevYonetimSistemi.Business.Abstracts;
using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Business.Rules;
using GorevYonetimSistemi.Data.Abstracts;
using GorevYonetimSistemi.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Business.Concretes
{
    public class ToDoTaskManager : IToDoTaskService
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly IMapper _mapper;
        private readonly ToDoTaskBusinessRules _rules;
        public ToDoTaskManager(IToDoTaskRepository toDoTaskRepository, IMapper mapper, ToDoTaskBusinessRules rules)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _mapper = mapper;
            _rules = rules;
        }
        public async Task AddAsync(ToDoTaskDto taskDto)
        {
            var task = _mapper.Map<ToDoTask>(taskDto);
            await _toDoTaskRepository.AddAsync(task);
            await _toDoTaskRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _toDoTaskRepository.GetByIdAsync(id);
            _rules.TaskExists(task);
            _toDoTaskRepository.Delete(task);
            await _toDoTaskRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDoTask>> GetAllAsync()
        {
            var tasks = await _toDoTaskRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ToDoTask>>(tasks);
        }

        public async Task<ToDoTask> GetByIdAsync(int id)
        {
            var task = await _toDoTaskRepository.GetByIdAsync(id);
            _rules.TaskExists(task);
            return _mapper.Map<ToDoTask>(task);
        }

        public async Task<IEnumerable<ToDoTask>> GetByStatusAsync(string status)
        {
            var tasks = await _toDoTaskRepository.GetAllAsync(predicate: u => u.Status == status);
            return _mapper.Map<IEnumerable<ToDoTask>>(tasks);
        }

        public async Task UpdateAsync(ToDoTaskDto taskDto)
        {
            var task = _mapper.Map<ToDoTask>(taskDto);
            _rules.TaskExists(task);
            _toDoTaskRepository.Update(task);
            await _toDoTaskRepository.SaveChangesAsync();
        }
    }
}
