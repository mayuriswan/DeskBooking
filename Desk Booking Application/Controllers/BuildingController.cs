using System.Collections.Generic;
using System.Threading.Tasks;
using Desk_Booking_Application.Models;
using Desk_Booking_Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Desk_Booking_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetAllBuildings()
        {
            var buildings = await _buildingService.GetAllBuildingsAsync();
            return Ok(buildings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuildingById(int id)
        {
            var building = await _buildingService.GetBuildingByIdAsync(id);
            if (building == null)
            {
                return NotFound();
            }
            return Ok(building);
        }

        [HttpPost]
        public async Task<ActionResult<Building>> AddBuilding(Building building)
        {
            var addedBuilding = await _buildingService.AddBuildingAsync(building);
            return CreatedAtAction(nameof(GetBuildingById), new { id = addedBuilding.BuildingId }, addedBuilding);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBuilding(int id, Building building)
        {
            if (id != building.BuildingId)
            {
                return BadRequest();
            }

            await _buildingService.UpdateBuildingAsync(building);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            await _buildingService.DeleteBuildingAsync(id);
            return NoContent();
        }
    }
}
