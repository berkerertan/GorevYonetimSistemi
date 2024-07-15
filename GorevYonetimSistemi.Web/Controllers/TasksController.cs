using GorevYonetimSistemi.Business.Abstracts;
using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Entities.Abstracts;
using GorevYonetimSistemi.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace GorevYonetimSistemi.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly IToDoTaskService _toDoTaskService;
        public TasksController(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }
        public async Task<IActionResult> Index()
        {
            var tasks = await _toDoTaskService.GetAllAsync();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoTaskDto task)
        {
            if (ModelState.IsValid)
            {
                await _toDoTaskService.AddToDoTaskAsync(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _toDoTaskService.GetToDoTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ToDoTaskDto task)
        {
            if (ModelState.IsValid)
            {
                await _toDoTaskService.UpdateToDoTaskAsync(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await _toDoTaskService.GetToDoTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _toDoTaskService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
