using System.Collections.Generic;
using System.Threading.Tasks;
using Desk_Booking_Application.Models;
using Desk_Booking_Application.Repository.Interface;
using Desk_Booking_Application.Services.Interface;

namespace Desk_Booking_Application.Services.Implementation
{
    public class DeskService : IDeskService
    {
        private readonly IDeskRepository _deskRepository;

        public DeskService(IDeskRepository deskRepository)
        {
            _deskRepository = deskRepository;
        }

        public async Task<IEnumerable<Desk>> GetAllDesksAsync()
        {
            return await _deskRepository.GetAllDesksAsync();
        }

        public async Task<Desk> GetDeskByIdAsync(int id)
        {
            return await _deskRepository.GetDeskByIdAsync(id);
        }

        public async Task<Desk> AddDeskAsync(Desk desk)
        {
            return await _deskRepository.AddDeskAsync(desk);
        }

        public async Task<Desk> UpdateDeskAsync(Desk desk)
        {
            return await _deskRepository.UpdateDeskAsync(desk);
        }

        public async Task DeleteDeskAsync(int id)
        {
            await _deskRepository.DeleteDeskAsync(id);
        }

        public async Task<IEnumerable<Desk>> GetDesksByFloorIdAsync(int floorId)
        {
            return await _deskRepository.GetDesksByFloorIdAsync(floorId);
        }
    }
}
