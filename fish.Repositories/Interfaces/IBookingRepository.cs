using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fish.Repositories.Models;

namespace fish.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAllBookings();
        IEnumerable<User> GetDoctors();
        Booking GetBookingById(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int id);
    }
}
