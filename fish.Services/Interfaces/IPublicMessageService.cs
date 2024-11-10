using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fish.Repositories.Models;

namespace Fish.Services.Interfaces
{
    public interface IPublicMessageService
    {
        IEnumerable<PublicMessage> GetAllMessages();
        void AddMessage(PublicMessage message);
    }
}
