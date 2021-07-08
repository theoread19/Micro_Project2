using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Web_API.DTOs.Request;

namespace Web_API.DTOs.Converter
{
    public class UserConverter
    {
        public UserRequest ToReq(UserModel model)
        {
            var req = new UserRequest()
            {
                Id = model.Id,
                Email = model.Email,
                Fullname = model.Fullname
            };

            return req;
        }
    }
}
