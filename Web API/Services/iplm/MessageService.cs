using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.DTOs.Converter;
using Web_API.DTOs.Request;

namespace Web_API.Services.iplm
{
    public class MessageService : IMessageService
    {

        private IMessageRepository _messageRepository;
        private MessageConverter converter = new MessageConverter();
        public MessageService(IMessageRepository messageRepository)
        {
            this._messageRepository = messageRepository;
        }
        public void Delete(long id)
        {
            this._messageRepository.Delete(id);
            this._messageRepository.SaveChange();
        }

        public IEnumerable<List<MessageRequest>> GetAll()
        {
            var model = this._messageRepository.GetAll();
            List<MessageRequest> reqs = new List<MessageRequest>();
            foreach(var item in model)
            {
                MessageRequest req = new MessageRequest();
                req = converter.ToReq(item);
                reqs.Add(req);
            }
            yield return reqs;
        }

        public MessageRequest GetById(long id)
        {
            return converter.ToReq(this._messageRepository.GetById(id));
        }

        public List<MessageRequest> GetMessagesBySenderId(long id)
        {
            var model = this._messageRepository.GetBySenderId(id);
            List<MessageRequest> reqs = new List<MessageRequest>();
            foreach (var item in model)
            {
                MessageRequest req = new MessageRequest();
                req = converter.ToReq(item);
                reqs.Add(req);
            }
            return reqs;
        }

        public void Insert(MessageRequest req)
        {
            this._messageRepository.Insert(converter.ToModel(req));
            this._messageRepository.SaveChange();
        }

        public void Update(MessageRequest req)
        {
            var model = this._messageRepository.GetById(req.Id);
            converter.ToModel(req, ref model);
            this._messageRepository.Update(model);
            this._messageRepository.SaveChange();
        }
    }
}
