using Microsoft.AspNetCore.Mvc;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    public class AccountController : Controller
    {
        // configure registration, forgot password
        // CRUD of a user
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterUserViewModel user)
        {
            if(ModelState.IsValid)
            {
                // registration / repo
            }
            return View(user);
        }
    }
}
