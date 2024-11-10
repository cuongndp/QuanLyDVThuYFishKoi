using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fish.Repositories.Models;

namespace Fish.Repositories.Interfaces
{
    public interface IPublicMessageRepository
    {
        IEnumerable<PublicMessage> GetAllMessages();
        void AddMessage(PublicMessage message);
    }
}
