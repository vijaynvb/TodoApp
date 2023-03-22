using Microsoft.AspNetCore.Identity;
using TodoAPI.Models;

namespace TodoAPI.Repository.MsSQL
{
    public class AccountDBRepository : IAccountRepository
    {
        public UserManager<ApplicationUser> _userManager { get; }
        public AccountDBRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApplicationUser> SignUpUserAsync(ApplicationUser user, string password)
        {
            var newUser = await _userManager.CreateAsync(user, password);
            if (newUser.Succeeded)
                return user;
            return null;
        }
    }
}
