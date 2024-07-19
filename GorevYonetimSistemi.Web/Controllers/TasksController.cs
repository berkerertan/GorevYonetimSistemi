using GorevYonetimSistemi.Business.Abstracts;
using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Core.Utilities.Helpers;
using GorevYonetimSistemi.Entities.Abstracts;
using GorevYonetimSistemi.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace GorevYonetimSistemi.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly IToDoTaskService _toDoTaskService;
        private readonly IUserService _userService;
        public TasksController(IToDoTaskService toDoTaskService, IUserService userService)
        {
            _toDoTaskService = toDoTaskService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _toDoTaskService.GetAllAsync();
            //ViewBag.StatusList = new SelectList(new[] { "new", "in_progress", "completed" });
            ViewBag.StatusList = new SelectList(EnumHelper.GetEnumDescriptions<Entities.Concretes.TaskStatus>());
            return View(tasks);
        }


        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoTaskDto task)
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userName == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var user = await _userService.GetAsync(predicate: p => p.Username == userName );
            task.UserId = user.Id;

            if (ModelState.IsValid)
            {
                task.CreationDate = DateTime.Now;
                task.Status = "new"; 

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
            ViewBag.StatusList = new SelectList(EnumHelper.GetEnumDescriptions<Entities.Concretes.TaskStatus>());
            return View(task);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ToDoTaskDto task)
        {
            ViewBag.StatusList = new SelectList(EnumHelper.GetEnumDescriptions<Entities.Concretes.TaskStatus>());
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetAsync(predicate: p => p.Username == userName);
            task.UserId = user.Id;
            if (ModelState.IsValid)
            {
                await _toDoTaskService.UpdateAsync(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        [Authorize]
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
            //ViewBag.StatusList = new SelectList(EnumHelper.GetEnumDescriptions<Entities.Concretes.TaskStatus>());
            var statusList = EnumHelper.GetEnumDescriptions<Entities.Concretes.TaskStatus>();
            statusList.Insert(0, "All");
            ViewBag.StatusList = new SelectList(statusList);
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
