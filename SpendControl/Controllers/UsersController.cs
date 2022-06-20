using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpendControl.Data;
using SpendControl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpendControl.Controllers
{
    public class UsersController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;

        public UsersController(ApplicationDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            Task<IList<User>> users = _userManager.GetUsersInRoleAsync("User");

            return View(users.Result);
        }
    }
}
