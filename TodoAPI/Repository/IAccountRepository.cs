using Microsoft.AspNetCore.Identity;
using TodoAPI.DTO;
using TodoAPI.Models;

namespace TodoAPI.Repository
{
    public interface IAccountRepository
    {
         Task<ApplicationUser> SignUpUserAsync(ApplicationUser user, string password);
        Task<SignInResult> SignInUserAsync(LoginDTO loginDTO);
        Task<ApplicationUser> FindUserByEmailAsync(string email);
    }
}
