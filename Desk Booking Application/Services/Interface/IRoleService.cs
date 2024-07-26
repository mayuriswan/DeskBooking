using Microsoft.AspNetCore.Identity;

namespace Desk_Booking_Application.Services.Interface
{
    public interface IRoleService
    {

        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<bool> RoleExistsAsync(string roleName);
        Task<IList<string>> GetRolesAsync();
    }
}
