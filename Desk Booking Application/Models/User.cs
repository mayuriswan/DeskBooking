using Microsoft.AspNetCore.Identity;

namespace Desk_Booking_Application.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
