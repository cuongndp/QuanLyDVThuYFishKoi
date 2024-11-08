﻿using Fish.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fish.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetDoctors();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}