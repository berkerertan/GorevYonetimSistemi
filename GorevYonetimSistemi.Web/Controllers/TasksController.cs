using GorevYonetimSistemi.Business.Abstracts;
using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Entities.Abstracts;
using GorevYonetimSistemi.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.StatusList = new SelectList(new[] { "new", "in_progress", "completed" });   
            return View(tasks);
        }


        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoTask task)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı ID'sini almak için gerekli olan kod buraya eklenmelidir
                task.CreationDate = DateTime.Now;
                task.Status = "new"; // Default status string olarak atanmıştır

                await _toDoTaskService.AddAsync(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _toDoTaskService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ToDoTask task)
        {
            if (ModelState.IsValid)
            {
                await _toDoTaskService.UpdateAsync(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _toDoTaskService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _toDoTaskService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> FilterByStatus(string selectedStatus)
        {
            IEnumerable<ToDoTask> tasks;
            ViewBag.StatusList = new SelectList(new[] { "All", "new", "in_progress", "completed" }, selectedStatus);
            if (selectedStatus == "All")
            {
                tasks = await _toDoTaskService.GetAllAsync();
            }
            else
            {
                tasks = await _toDoTaskService.GetByStatusAsync(selectedStatus);
            }
            
            return View("Index", tasks);
        }
    }

}
