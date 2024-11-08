using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using fish.Repositories.Interfaces;
using fish.Repositories.Repositories;
using fish.Services.Interfaces;
using Fish.Repositories.Models;

namespace fish.Services.Services
{
    public class DichVuService : IDichVuService
    {
        private readonly IServiceModelRepository _serviceRepository;
        private readonly IUserRepository _userRepository;

        // Constructor nhận cả hai dependencies
        public DichVuService(IServiceModelRepository serviceRepository, IUserRepository userRepository)
        {
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public List<ServiceModel> GetAllServices()
        {
            return _serviceRepository.GetAllServiceModels().ToList();
        }
        // Thêm `IUserRepository` vào constructor
        

        
        public List<User> GetDoctors()
        {
            // Lấy danh sách người dùng có vai trò "Doctor"
            return _userRepository.GetDoctors().ToList();
        }
    }
}

