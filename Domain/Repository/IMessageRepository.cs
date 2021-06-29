using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IMessageRepository
    {
        public List<MessageModel> GetAll();
        public MessageModel GetById(long id);
        public void Insert(MessageModel model);
        public void Update(MessageModel model);
        public void Delete(long id);
        public void SaveChange();
    }
}
