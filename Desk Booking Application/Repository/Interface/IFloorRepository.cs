using Desk_Booking_Application.Models;

namespace Desk_Booking_Application.Repository.Interface
{
    public interface IFloorRepository
    {
        Task<IEnumerable<Floor>> GetAllFloorsAsync();
        Task<Floor> GetFloorByIdAsync(int id);
        Task<Floor> AddFloorAsync(Floor floor);
        Task<Floor> UpdateFloorAsync(Floor floor);
        Task DeleteFloorAsync(int id);
        Task<IEnumerable<Floor>> GetFloorsByBuildingIdAsync(int buildingId); // New method

    }
}
