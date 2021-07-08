using Domain.Models;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using UserProtoBufService;

namespace Infrastructure.Kafka.Consumer
{
    public class HandleConsumer
    {
        private IUserRepository _userRepository;

        public HandleConsumer(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public void Handle(UserProtoReq req)
        {
//            if (req != null)
            {
                UserModel model = new UserModel
                {
                    Email = req.Email,
                    Fullname = req.Fullname,
                    //Id = req.UserId
                };
                this._userRepository.Insert(model);
                this._userRepository.SaveChange();
            }
        }
    }
}
