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
    public class DoctorService : IDoctorService
    {
        private readonly IBookingRepository _bookingRepository;

        public DoctorService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<Booking> GetBookingsForDoctor(int doctorId)
        {
            return _bookingRepository.GetAllBookings().Where(b => b.DoctorId == doctorId).ToList();
        }
    }
}
