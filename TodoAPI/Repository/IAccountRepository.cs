using TodoAPI.Models;

namespace TodoAPI.Repository
{
    public interface IAccountRepository
    {
         Task<ApplicationUser> SignUpUserAsync(ApplicationUser user, string password);
    }
}
