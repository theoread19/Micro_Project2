using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.DTOs.Request;

namespace Web_API.Services
{
    public interface IMessageService
    {
        public IEnumerable<List<MessageRequest>> GetAll();
        public MessageRequest GetById(long id);
        public void Insert(MessageRequest req);
        public void Update(MessageRequest req);
        public void Delete(long id);
    }
}
