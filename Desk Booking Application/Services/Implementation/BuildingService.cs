using System.Collections.Generic;
using System.Threading.Tasks;
using Desk_Booking_Application.Models;
using Desk_Booking_Application.Repository.Interface;
using Desk_Booking_Application.Services.Interface;

namespace Desk_Booking_Application.Services.Implementation
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<IEnumerable<Building>> GetAllBuildingsAsync()
        {
            return await _buildingRepository.GetAllBuildingsAsync();
        }

        public async Task<Building> GetBuildingByIdAsync(int id)
        {
            return await _buildingRepository.GetBuildingByIdAsync(id);
        }

        public async Task<Building> AddBuildingAsync(Building building)
        {
            return await _buildingRepository.AddBuildingAsync(building);
        }

        public async Task<Building> UpdateBuildingAsync(Building building)
        {
            return await _buildingRepository.UpdateBuildingAsync(building);
        }

        public async Task DeleteBuildingAsync(int id)
        {
            await _buildingRepository.DeleteBuildingAsync(id);
        }
    }
}
