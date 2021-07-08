using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        /*        ;
                public MessageModel GetById(long id);
                public List<MessageModel> GetBySenderId(long id);
                public void Update(MessageModel model);
                public void Delete(long id);
                public void SaveChange();*/
        public List<UserModel> GetAll();
        public void Insert(UserModel model);
        public void SaveChange();
    }
}
