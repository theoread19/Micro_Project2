using Domain.Models;
using Domain.Repository;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {

        private MessageDBContext _context;
        public UserRepository()
        {
            this._context = new MessageDBContext();
        }

        public List<UserModel> GetAll()
        {
            return this._context.UserModels.ToList();
        }

        public void Insert(UserModel model)
        {
            this._context.UserModels.Add(model);
        }

        public void SaveChange()
        {
            try
            {
                this._context.SaveChanges();
            } catch (Exception e)
            {
                throw new Exception("" + e);
            }
        }
    }
}
