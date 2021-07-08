using Domain.Models;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.DTOs.Converter;
using Web_API.DTOs.Request;

namespace Web_API.Services.iplm
{
    public class UserService : IUserService
    {

        private IUserRepository _userRepository;
        private UserConverter _userConverter;
        public UserService (IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            this._userConverter = new UserConverter();
        }

        public IEnumerable<List<UserRequest>> GetAll()
        {
            List<UserModel> models = this._userRepository.GetAll();
            List<UserRequest> reqs = new List<UserRequest>();
            foreach (var item in models)
            {
                var req = this._userConverter.ToReq(item);
                reqs.Add(req);
            }
            yield return reqs;
        }

        public UserRequest GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
