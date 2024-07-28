using System.Collections.Generic;
using System.Threading.Tasks;
using Desk_Booking_Application.Models;
using Desk_Booking_Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Desk_Booking_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IFloorService _floorService;

        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Floor>>> GetAllFloors()
        {
            var floors = await _floorService.GetAllFloorsAsync();
            return Ok(floors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Floor>> GetFloorById(int id)
        {
            var floor = await _floorService.GetFloorByIdAsync(id);
            if (floor == null)
            {
                return NotFound();
            }
            return Ok(floor);
        }

        [HttpPost]
        public async Task<ActionResult<Floor>> AddFloor(Floor floor)
        {
            var addedFloor = await _floorService.AddFloorAsync(floor);
            return CreatedAtAction(nameof(GetFloorById), new { id = addedFloor.FloorId }, addedFloor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFloor(int id, Floor floor)
        {
            if (id != floor.FloorId)
            {
                return BadRequest();
            }
            floor.Building = null;
            await _floorService.UpdateFloorAsync(floor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFloor(int id)
        {
            await _floorService.DeleteFloorAsync(id);
            return NoContent();
        }
        [HttpGet("building/{buildingId}")]
        public async Task<ActionResult<IEnumerable<Floor>>> GetFloorsByBuildingId(int buildingId)
        {
            var floors = await _floorService.GetFloorsByBuildingIdAsync(buildingId);
            return Ok(floors);
        }
    }
}
