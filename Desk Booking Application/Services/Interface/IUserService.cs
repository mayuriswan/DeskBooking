using Desk_Booking_Application.Models;
using Microsoft.AspNetCore.Identity;

namespace Desk_Booking_Application.Services.Interface
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterModel model);
        Task<bool> ValidateUserAsync(LoginModel model);
        Task<IList<string>> GetUserRolesAsync(string email);
        Task AddUserToRoleAsync(User user, string role);

    }
}
