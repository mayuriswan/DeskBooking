namespace Desk_Booking_Application.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
        public int DeskId { get; set; }
        public Desk? Desk { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
