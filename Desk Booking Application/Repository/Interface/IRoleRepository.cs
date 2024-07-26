using Microsoft.AspNetCore.Identity;

namespace Desk_Booking_Application.Repository.Interface
{
    public interface IRoleRepository
    {
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<bool> RoleExistsAsync(string roleName);
        Task<IList<string>> GetRolesAsync();
    }
}
