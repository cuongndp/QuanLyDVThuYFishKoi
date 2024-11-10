using System.Collections.Generic;
using Fish.Repositories.Interfaces;
using Fish.Repositories.Models;
using Fish.Services.Interfaces;

namespace Fish.Services.Services
{
    public class PublicMessageService : IPublicMessageService
    {
        private readonly IPublicMessageRepository _messageRepository;

        public PublicMessageService(IPublicMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IEnumerable<PublicMessage> GetAllMessages()
        {
            return _messageRepository.GetAllMessages();
        }

        public void AddMessage(PublicMessage message)
        {
            _messageRepository.AddMessage(message);
        }
    }
}