using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fish.Repositories.Interfaces;
using fish.Services.Interfaces;
using System.Security.Cryptography;
using Fish.Repositories.Models;

namespace fish.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookingRepository _bookingRepository;

        public AccountService(IUserRepository userRepository, IBookingRepository bookingRepository)
        {
            _userRepository = userRepository;
            _bookingRepository = bookingRepository;
        }

        public User Login(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            return _userRepository.GetAllUsers().FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool Register(User user)
        {
            if (_userRepository.GetAllUsers().Any(u => u.Username == user.Username || u.Email == user.Email || u.PhoneNumber == user.PhoneNumber))
            {
                return false;
            }

            user.Password = HashPassword(user.Password);
            _userRepository.AddUser(user);
            return true;
        }

        public List<User> GetDoctors()
        {
            return _userRepository.GetAllUsers().Where(u => u.Role == "Doctor").ToList();
        }

        public bool Booking(Booking booking)
        {
            try
            {
                _bookingRepository.AddBooking(booking);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
