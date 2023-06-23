using DataAccessLayer.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;

namespace BlogApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsers();
            return View(users);
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Username,Role,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Email,Username,Role,Password")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _userService.EditUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
