using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using fish.Repositories.Interfaces;
using Fish.Repositories.Models;
using Fish.Repositories;

namespace fish.Repositories.Repositories
{
    public class ServiceModelRepository : IServiceModelRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ServiceModel> GetAllServiceModels()
        {
            return _context.ServiceModels.ToList();
        }

        public ServiceModel GetServiceModelById(int id)
        {
            return _context.ServiceModels.Find(id);
        }

        public void AddServiceModel(ServiceModel serviceModel)
        {
            _context.ServiceModels.Add(serviceModel);
            _context.SaveChanges();
        }

        public void UpdateServiceModel(ServiceModel serviceModel)
        {
            _context.Entry(serviceModel).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteServiceModel(int id)
        {
            var serviceModel = _context.ServiceModels.Find(id);
            if (serviceModel != null)
            {
                _context.ServiceModels.Remove(serviceModel);
                _context.SaveChanges();
            }
        }
    }
}
