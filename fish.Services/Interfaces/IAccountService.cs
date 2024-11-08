using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fish.Repositories.Models;

namespace fish.Services.Interfaces
{
    public interface IAccountService
    {
        User Login(string username, string password);
        string HashPassword(string password);
        bool Register(User user);
        List<User> GetDoctors();
        bool Booking(Booking booking);
    }
}
