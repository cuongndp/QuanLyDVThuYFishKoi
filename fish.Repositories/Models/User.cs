using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Fish.Repositories.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Vai trò: Customer, Doctor, Admin
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
