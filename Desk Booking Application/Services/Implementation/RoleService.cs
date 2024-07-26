using Desk_Booking_Application.Repository.Interface;
using Desk_Booking_Application.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace Desk_Booking_Application.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            return await _roleRepository.CreateRoleAsync(roleName);
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleRepository.RoleExistsAsync(roleName);
        }

        public async Task<IList<string>> GetRolesAsync()
        {
            return await _roleRepository.GetRolesAsync();
        }
    }
}
