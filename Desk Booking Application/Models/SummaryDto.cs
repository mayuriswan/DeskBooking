namespace Desk_Booking_Application.Models
{
    public class SummaryDto
    {
        public int Buildings { get; set; }
        public int Floors { get; set; }
        public int Desks { get; set; }
        public int ActiveBookings { get; set; }
        public int AvailableDesks { get; set; }
    }
}
