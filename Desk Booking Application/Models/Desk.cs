namespace Desk_Booking_Application.Models
{
    public class Desk
    {
        public int DeskId { get; set; }
        public string DeskName { get; set; }
        public int FloorId { get; set; }
        public Floor? Floor { get; set; }
        public string Status { get; set; } // Booked/Available/Inactive
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }
}
