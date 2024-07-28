using Desk_Booking_Application.Models;
using Desk_Booking_Application.Services.Interface;
using Microsoft.EntityFrameworkCore;

public class SummaryService : ISummaryService
{
    private readonly DeskBookingContext _context;

    public SummaryService(DeskBookingContext context)
    {
        _context = context;
    }

    public async Task<SummaryDto> GetSummaryAsync()
    {
        var buildingsCount = await _context.Buildings.CountAsync();
        var floorsCount = await _context.Floors.CountAsync();
        var desksCount = await _context.Desks.CountAsync();
        var activeBookingsCount = await _context.Bookings.CountAsync();
        var availableDesksCount = await _context.Desks.CountAsync(d => d.Status == "Available");

        return new SummaryDto
        {
            Buildings = buildingsCount,
            Floors = floorsCount,
            Desks = desksCount,
            ActiveBookings = activeBookingsCount,
            AvailableDesks = availableDesksCount
        };
    }
}
