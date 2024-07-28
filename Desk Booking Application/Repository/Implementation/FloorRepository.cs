using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desk_Booking_Application.Models;
using Desk_Booking_Application.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Desk_Booking_Application.Repository.Implementation
{
    public class FloorRepository : IFloorRepository
    {
        private readonly DeskBookingContext _context;

        public FloorRepository(DeskBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Floor>> GetAllFloorsAsync()
        {
            return await _context.Floors.Include(f => f.Building).ToListAsync();
        }

        public async Task<Floor> GetFloorByIdAsync(int id)
        {
            return await _context.Floors.Include(f => f.Building)
                                        .FirstOrDefaultAsync(f => f.FloorId == id);
        }

        public async Task<Floor> AddFloorAsync(Floor floor)
        {
            _context.Floors.Add(floor);
            await _context.SaveChangesAsync();
            return floor;
        }

        public async Task<Floor> UpdateFloorAsync(Floor floor)
        {
            _context.Floors.Update(floor);
            await _context.SaveChangesAsync();
            return floor;
        }

        public async Task DeleteFloorAsync(int id)
        {
            var floor = await _context.Floors.FindAsync(id);
            if (floor != null)
            {
                _context.Floors.Remove(floor);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Floor>> GetFloorsByBuildingIdAsync(int buildingId)
        {
            return await _context.Floors
                                 .Where(f => f.BuildingId == buildingId)
                                 .Include(f => f.Building)
                                 .ToListAsync();
        }
    }
}
