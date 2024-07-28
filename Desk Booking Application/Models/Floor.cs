namespace Desk_Booking_Application.Models
{
    public class Floor
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; }
        public int BuildingId { get; set; }
        public Building? Building { get; set; }
        public string FloorMap { get; set; } // Path to the floor map image
        public ICollection<Desk>? Desks { get; set; }
    }
}
