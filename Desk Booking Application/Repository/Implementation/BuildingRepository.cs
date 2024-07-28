using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desk_Booking_Application.Models;
using Desk_Booking_Application.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Desk_Booking_Application.Repository.Implementation
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly DeskBookingContext _context;

        public BuildingRepository(DeskBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Building>> GetAllBuildingsAsync()
        {
            return await _context.Buildings.Include(b => b.Floors).ToListAsync();
        }

        public async Task<Building> GetBuildingByIdAsync(int id)
        {
            return await _context.Buildings.Include(b => b.Floors)
                                           .FirstOrDefaultAsync(b => b.BuildingId == id);
        }

        public async Task<Building> AddBuildingAsync(Building building)
        {
            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();
            return building;
        }

        public async Task<Building> UpdateBuildingAsync(Building building)
        {
            _context.Buildings.Update(building);
            await _context.SaveChangesAsync();
            return building;
        }

        public async Task DeleteBuildingAsync(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building != null)
            {
                _context.Buildings.Remove(building);
                await _context.SaveChangesAsync();
            }
        }
    }
}
