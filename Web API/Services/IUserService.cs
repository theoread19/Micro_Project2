using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.DTOs.Request;

namespace Web_API.Services
{
    public interface IUserService
    {
        public IEnumerable<List<UserRequest>> GetAll();
        public UserRequest GetById(long id);
/*        public void Insert(MessageRequest req);
        public void Update(MessageRequest req);
        public void Delete(long id);
        public List<MessageRequest> GetMessagesBySenderId(long id);*/
    }
}
