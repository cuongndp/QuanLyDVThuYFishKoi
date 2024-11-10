using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fish.Repositories.Models;


namespace fish.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();

        IEnumerable<User> GetDoctors();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
