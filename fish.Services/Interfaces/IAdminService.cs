using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fish.Repositories.Models;

namespace fish.Services.Interfaces
{
    public interface IAdminService
    {
        List<ServiceModel> GetAllServices();
        List<User> GetAllUsers();
        List<Booking> GetAllBookings();
        ServiceModel GetServiceById(int id);
        User GetUserById(int id);
        Booking GetBookingById(int id);
        void AddService(ServiceModel service);
        void UpdateService(ServiceModel service);
        void DeleteService(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int id);
        void AssignDoctor(int bookingId, int doctorId);
        List<User> GetDoctors();
    }
}
