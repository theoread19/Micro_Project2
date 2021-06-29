using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.DTOs.Request;

namespace Web_API.DTOs.Converter
{
    public class MessageConverter
    {
        public MessageRequest ToReq(MessageModel model)
        {
            var req = new MessageRequest
            {
                Content = model.Content,
                Id = model.Id,
                Title = model.Title,
                SenderId = model.SenderId,
                RecipientId = model.RecipientId,
                CreateDate = model.CreateDate
            };
            return req;
        }

        public MessageModel ToModel(MessageRequest req)
        {
            var model = new MessageModel
            {
                Content = req.Content,
                Title = req.Title,
                SenderId = req.SenderId,
                RecipientId = req.RecipientId,
                CreateDate = req.CreateDate
            };
            return model;
        }

        public void ToModel(MessageRequest req, ref MessageModel model)
        {
            model.Content = req.Content;
            model.Title = req.Title;
            model.SenderId = req.SenderId;
            model.RecipientId = req.RecipientId;
        }
    }
}
