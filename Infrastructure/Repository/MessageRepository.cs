using Domain.Models;
using Domain.Repository;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private MessageDBContext context;
        
        public MessageRepository()
        {
            context = new MessageDBContext();
        }

        public void Delete(long id)
        {
            var std = context.MessageTable.Find(id);
            context.Remove(std);
        }

        public List<MessageModel> GetAll()
        {
            return context.MessageTable.ToList();
        }

        public MessageModel GetById(long id)
        {
            return context.MessageTable.Find(id);
        }

        public List<MessageModel> GetBySenderId(long id)
        {
            return context.MessageTable.Where(e => e.SenderId == id).ToList();
        }

        public void Insert(MessageModel model)
        {
            context.MessageTable.Add(model);
        }

        public void SaveChange()
        {
            context.SaveChanges();
        }

        public void Update(MessageModel model)
        {
            context.MessageTable.Find(model.Id);
            context.MessageTable.Update(model);
        }
    }
}
