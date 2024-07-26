using Desk_Booking_Application.Models;
using Microsoft.AspNetCore.Identity;

namespace Desk_Booking_Application.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUserAsync(User user, string password);
        Task<User> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IList<string>> GetUserRolesAsync(User user);
    }
}
