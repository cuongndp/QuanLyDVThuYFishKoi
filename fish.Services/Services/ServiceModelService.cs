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
    public class ServiceModelService : IServiceModelService
    {
        private readonly IServiceModelRepository _serviceModelRepository;

        public ServiceModelService(IServiceModelRepository serviceModelRepository)
        {
            _serviceModelRepository = serviceModelRepository;
        }

        public IEnumerable<ServiceModel> GetAllServiceModels()
        {
            return _serviceModelRepository.GetAllServiceModels();
        }

        public ServiceModel GetServiceModelById(int id)
        {
            return _serviceModelRepository.GetServiceModelById(id);
        }

        public void AddServiceModel(ServiceModel serviceModel)
        {
            _serviceModelRepository.AddServiceModel(serviceModel);
        }

        public void UpdateServiceModel(ServiceModel serviceModel)
        {
            _serviceModelRepository.UpdateServiceModel(serviceModel);
        }

        public void DeleteServiceModel(int id)
        {
            _serviceModelRepository.DeleteServiceModel(id);
        }
    }
}

