using System.Collections.Generic;
using System.Linq;
using Fish.Repositories.Interfaces;
using Fish.Repositories.Models;

namespace Fish.Repositories
{
    public class PublicMessageRepository : IPublicMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public PublicMessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PublicMessage> GetAllMessages()
        {
            return _context.PublicMessages.OrderBy(m => m.Id).ToList();
        }

        public void AddMessage(PublicMessage message)
        {
            _context.PublicMessages.Add(message);
            _context.SaveChanges();
        }
    }
}
