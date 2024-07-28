using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desk_Booking_Application.Models;
using Desk_Booking_Application.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Desk_Booking_Application.Repository.Implementation
{
    public class DeskRepository : IDeskRepository
    {
        private readonly DeskBookingContext _context;

        public DeskRepository(DeskBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Desk>> GetAllDesksAsync()
        {
            return await _context.Desks.Include(d => d.Floor).ToListAsync();
        }

        public async Task<Desk> GetDeskByIdAsync(int id)
        {
            return await _context.Desks.Include(d => d.Floor)
                                       .FirstOrDefaultAsync(d => d.DeskId == id);
        }

        public async Task<Desk> AddDeskAsync(Desk desk)
        {
            _context.Desks.Add(desk);
            await _context.SaveChangesAsync();
            return desk;
        }

        public async Task<Desk> UpdateDeskAsync(Desk desk)
        {
            _context.Desks.Update(desk);
            await _context.SaveChangesAsync();
            return desk;
        }

        public async Task DeleteDeskAsync(int id)
        {
            var desk = await _context.Desks.FindAsync(id);
            if (desk != null)
            {
                _context.Desks.Remove(desk);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Desk>> GetDesksByFloorIdAsync(int floorId)
        {
            return await _context.Desks
                                 .Where(d => d.FloorId == floorId)
                                 .Include(d => d.Floor)
                                 .ToListAsync();
        }
    }
}
