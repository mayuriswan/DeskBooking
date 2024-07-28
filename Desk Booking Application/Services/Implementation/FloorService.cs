using System.Collections.Generic;
using System.Threading.Tasks;
using Desk_Booking_Application.Models;
using Desk_Booking_Application.Repository.Interface;
using Desk_Booking_Application.Services.Interface;

namespace Desk_Booking_Application.Services.Implementation
{
    public class FloorService : IFloorService
    {
        private readonly IFloorRepository _floorRepository;

        public FloorService(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public async Task<IEnumerable<Floor>> GetAllFloorsAsync()
        {
            return await _floorRepository.GetAllFloorsAsync();
        }

        public async Task<Floor> GetFloorByIdAsync(int id)
        {
            return await _floorRepository.GetFloorByIdAsync(id);
        }

        public async Task<Floor> AddFloorAsync(Floor floor)
        {
            return await _floorRepository.AddFloorAsync(floor);
        }

        public async Task<Floor> UpdateFloorAsync(Floor floor)
        {
            return await _floorRepository.UpdateFloorAsync(floor);
        }

        public async Task DeleteFloorAsync(int id)
        {
            await _floorRepository.DeleteFloorAsync(id);
        }
        public async Task<IEnumerable<Floor>> GetFloorsByBuildingIdAsync(int buildingId)
        {
            return await _floorRepository.GetFloorsByBuildingIdAsync(buildingId);
        }
    }
}
