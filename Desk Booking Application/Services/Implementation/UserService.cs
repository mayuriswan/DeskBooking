using Desk_Booking_Application.Models;
using Desk_Booking_Application.Repository.Interface;
using Desk_Booking_Application.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace Desk_Booking_Application.Services.Implementation
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;


        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
    

        public async Task<IdentityResult> RegisterUserAsync(RegisterModel model)
        {
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmployeeId = model.EmployeeId
            };

            var result = await _userRepository.RegisterUserAsync(user, model.Password);
            if (result.Succeeded)
            {
                await AddUserToRoleAsync(user, "Employee");
            }

            return result;
        }
        public async Task AddUserToRoleAsync(User user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<bool> ValidateUserAsync(LoginModel model)
        {
            var user = await _userRepository.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return false;
            }

            return await _userRepository.CheckPasswordAsync(user, model.Password);
        }

        public async Task<IList<string>> GetUserRolesAsync(string email)
        {
            var user = await _userRepository.FindByEmailAsync(email);
            return await _userRepository.GetUserRolesAsync(user);
        }
        public async Task<User> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
