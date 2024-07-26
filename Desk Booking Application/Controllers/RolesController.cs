using Desk_Booking_Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateRole([FromBody] string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
        {
            return BadRequest(new { message = "Role name cannot be empty" });
        }

        try
        {
            var result = await _roleService.CreateRoleAsync(roleName);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role created successfully" });
            }

            return BadRequest(new { errors = result.Errors });
        }
        catch (Exception ex)
        {
            // Log the exception (not shown here)
            return StatusCode(500, new { message = "An error occurred while processing your request.", details = ex.Message });
        }
    }

    [HttpGet("all")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetRoles()
    {
        try
        {
            var roles = await _roleService.GetRolesAsync();
            return Ok(roles);
        }
        catch (Exception ex)
        {
            // Log the exception (not shown here)
            return StatusCode(500, new { message = "An error occurred while processing your request.", details = ex.Message });
        }
    }
}
