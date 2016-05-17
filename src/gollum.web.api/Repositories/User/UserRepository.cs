
using System;
using System.Collections.Generic;
using gollum.web.common.Models.User;

namespace gollum.web.api.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        public UserModel Add(UserModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid objId)
        {
            throw new NotImplementedException();
        }

        public UserModel Get(Guid objId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}