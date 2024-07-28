using Desk_Booking_Application.Models;

namespace Desk_Booking_Application.Services.Interface
{
    public interface IDeskService
    {
        Task<IEnumerable<Desk>> GetAllDesksAsync();
        Task<Desk> GetDeskByIdAsync(int id);
        Task<Desk> AddDeskAsync(Desk desk);
        Task<Desk> UpdateDeskAsync(Desk desk);
        Task DeleteDeskAsync(int id);
        Task<IEnumerable<Desk>> GetDesksByFloorIdAsync(int floorId);
    }
}
