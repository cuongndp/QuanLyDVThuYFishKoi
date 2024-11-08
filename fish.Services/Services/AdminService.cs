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
    public class AdminService : IAdminService
    {
        private readonly IServiceModelRepository _serviceRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;

        public AdminService(IServiceModelRepository serviceRepository, IUserRepository userRepository, IBookingRepository bookingRepository)
        {
            _serviceRepository = serviceRepository;
            _userRepository = userRepository;
            _bookingRepository = bookingRepository;
        }

        public List<ServiceModel> GetAllServices() => _serviceRepository.GetAllServiceModels().ToList();
        public List<User> GetAllUsers() => _userRepository.GetAllUsers().ToList();
        public List<Booking> GetAllBookings() => _bookingRepository.GetAllBookings().ToList();

        public ServiceModel GetServiceById(int id) => _serviceRepository.GetServiceModelById(id);
        public User GetUserById(int id) => _userRepository.GetUserById(id);
        public Booking GetBookingById(int id) => _bookingRepository.GetBookingById(id);

        public void AddService(ServiceModel service) => _serviceRepository.AddServiceModel(service);
        public void UpdateService(ServiceModel service) => _serviceRepository.UpdateServiceModel(service);
        public void DeleteService(int id) => _serviceRepository.DeleteServiceModel(id);

        public void UpdateUser(User user) => _userRepository.UpdateUser(user);
        public void DeleteUser(int id) => _userRepository.DeleteUser(id);

        public void UpdateBooking(Booking booking) => _bookingRepository.UpdateBooking(booking);
        public void DeleteBooking(int id) => _bookingRepository.DeleteBooking(id);

        public void AssignDoctor(int bookingId, int doctorId)
        {
            var booking = _bookingRepository.GetBookingById(bookingId);
            if (booking != null)
            {
                booking.DoctorId = doctorId;
                _bookingRepository.UpdateBooking(booking);
            }
        }

        public List<User> GetDoctors() => _userRepository.GetAllUsers().Where(u => u.Role == "Doctor").ToList();
    }
}

