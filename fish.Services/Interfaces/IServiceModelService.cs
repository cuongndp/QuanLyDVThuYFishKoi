using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fish.Repositories.Models;

namespace fish.Services.Interfaces
{
    public interface IServiceModelService
    {
        IEnumerable<ServiceModel> GetAllServiceModels();
        ServiceModel GetServiceModelById(int id);
        void AddServiceModel(ServiceModel serviceModel);
        void UpdateServiceModel(ServiceModel serviceModel);
        void DeleteServiceModel(int id);
    }
}
