using Desk_Booking_Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = await _userService.RegisterUserAsync(model);
            if (result.Succeeded)
            {
                return Ok(new { message = "Registration successful" });
            }

            return BadRequest(new { errors = result.Errors });
        }
        catch (Exception ex)
        {
            // Log the exception (not shown here)
            return StatusCode(500, new { message = "An error occurred while processing your request.", details = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var isValid = await _userService.ValidateUserAsync(model);
            if (isValid)
            {
                var user = await _userService.FindByEmailAsync(model.Email);
                var firstName = user?.FirstName;
                return Ok(new { message = "Login successful", firstName });
            }

            return Unauthorized(new { message = "Invalid login attempt" });
        }
        catch (Exception ex)
        {
            // Log the exception (not shown here)
            return StatusCode(500, new { message = "An error occurred while processing your request.", details = ex.Message });
        }
    }

    [HttpGet("roles/{email}")]
    public async Task<IActionResult> GetUserRoles(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return BadRequest(new { message = "Email cannot be empty" });
        }

        try
        {
            var roles = await _userService.GetUserRolesAsync(email);
            if (roles == null || roles.Count == 0)
            {
                return NotFound(new { message = "User not found or no roles assigned" });
            }

            return Ok(roles);
        }
        catch (Exception ex)
        {
            // Log the exception (not shown here)
            return StatusCode(500, new { message = "An error occurred while processing your request.", details = ex.Message });
        }
    }
}

public class RegisterModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeId { get; set; }
}

public class LoginModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}
