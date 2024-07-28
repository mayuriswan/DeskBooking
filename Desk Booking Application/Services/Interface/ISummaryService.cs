using Desk_Booking_Application.Models;

namespace Desk_Booking_Application.Services.Interface
{
    public interface ISummaryService
    {
        Task<SummaryDto> GetSummaryAsync();

    }
}
