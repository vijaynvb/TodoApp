using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp.Controllers
{
    public class AccountController : Controller
    {
        // configure registration, forgot password
        // CRUD of a user
        // you can manage user activities CRUD
        private UserManager<ApplicationUser> _userManager { get; }
        // login user details 
        private SignInManager<ApplicationUser> _signInManager { get; }
        public AccountController(UserManager<ApplicationUser> userManager, 
                                SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel userViewModel)
        {
            if(ModelState.IsValid)
            {
                var userModel = new ApplicationUser
                {
                    UserName = userViewModel.Email,
                    Email = userViewModel.Email,
                    FirstName = userViewModel.FirstName,    
                    LastName = userViewModel.LastName
                };
                var result = await _userManager.CreateAsync(userModel, userViewModel.Password);
                if (result.Succeeded)
                {
                    // login the user automatically
                    await _signInManager.SignInAsync(userModel, isPersistent: false);
                    return RedirectToAction("GetAllTodos", "Todo");

                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userViewModel);
        }
    }
}
