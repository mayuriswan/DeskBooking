using System.Drawing;

namespace Desk_Booking_Application.Models
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public ICollection<Floor> Floors { get; set; }
    }
}
