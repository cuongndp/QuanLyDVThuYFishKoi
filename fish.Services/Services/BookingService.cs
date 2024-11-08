using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fish.Repositories.Interfaces;
using fish.Services.Interfaces;
using Fish.Repositories.Models;

namespace fish.Services.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings();
        }

        public Booking GetBookingById(int id)
        {
            return _bookingRepository.GetBookingById(id);
        }

        public void AddBooking(Booking booking)
        {
            _bookingRepository.AddBooking(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.UpdateBooking(booking);
        }

        public void DeleteBooking(int id)
        {
            _bookingRepository.DeleteBooking(id);
        }
    }
}

