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
        public RoleManager<IdentityRole> _roleManager { get; }

        public AccountController(UserManager<ApplicationUser> userManager, 
                                SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
                    // add roles to it and allow him to login
                    //var roles = _roleManager.Roles.ToList();
                    var role = _roleManager.Roles.FirstOrDefault(r => r.Name == "User");
                    if (role != null)
                    {
                        //var roleResult = await _userManager.AddToRolesAsync(userModel, roles.Select(s => s.Name).ToList());
                        var roleResult = await _userManager.AddToRoleAsync(userModel, role.Name);
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError(String.Empty, "User Role cannot be assigned");
                        }
                    }
          
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                // login activity -> cookie [Roles and Claims]
                var result = await _signInManager.PasswordSignInAsync(userViewModel.UserName, userViewModel.Password, userViewModel.RememberMe, false);
                //login cookie and transfter to the client 
                if (result.Succeeded)
                {
                    return RedirectToAction("GetAllTodos", "Todo");
                }
                ModelState.AddModelError(string.Empty, "invalid login credentials");
            }
            return View(userViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
