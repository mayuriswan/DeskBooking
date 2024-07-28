using Desk_Booking_Application.Models;

namespace Desk_Booking_Application.Services.Interface
{
    public interface IBuildingService
    {
        Task<IEnumerable<Building>> GetAllBuildingsAsync();
        Task<Building> GetBuildingByIdAsync(int id);
        Task<Building> AddBuildingAsync(Building building);
        Task<Building> UpdateBuildingAsync(Building building);
        Task DeleteBuildingAsync(int id);
    }
}
