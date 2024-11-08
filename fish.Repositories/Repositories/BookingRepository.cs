using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using fish.Repositories.Interfaces;
using Fish.Repositories.Models;
using Fish.Repositories;

namespace fish.Repositories.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetBookingById(int id)
        {
            return _context.Bookings.Find(id);
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void UpdateBooking(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteBooking(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
        public IEnumerable<User> GetDoctors()
        {
            // Lọc người dùng có vai trò "Doctor"
            return _context.Users.Where(u => u.Role == "Doctor").ToList();
        }
    }
}
