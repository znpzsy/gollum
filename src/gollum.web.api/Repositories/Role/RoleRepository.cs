using System;
using System.Collections.Generic;
using gollum.web.common.Models.Role;
using System.Collections.Concurrent;

namespace gollum.web.api.Repositories.Role
{
    public class RoleRepository : IRoleRepository
    {
        static ConcurrentDictionary<string, RoleModel> Roles = new ConcurrentDictionary<string, RoleModel>();

        public RoleRepository()
        {
            Add(Guid.NewGuid(), new RoleModel
            {
                Name = "RoleForOrganization",
                Key = Guid.NewGuid(),
                Description = "Role Description A",
                Tags = new string[] { "Role tag 1", "Role tag 2", "Role tag 3" }
            });
            Add(Guid.NewGuid(), new RoleModel
            {
                Name = "RoleForPersonalUser",
                Key = Guid.NewGuid(),
                Description = "Role Description B",
                Tags = new string[] { "Role tag 1", "Role tag 2", "Role tag 5", "Role tag 6", "Role tag 8" }
            });
        }

        public RoleModel Add(Guid applicationId, RoleModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid applicationId, Guid objId)
        {
            throw new NotImplementedException();
        }

        public RoleModel Get(Guid applicationId, Guid objId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleModel> GetAll(Guid applicationId)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid applicationId, RoleModel model)
        {
            throw new NotImplementedException();
        }
    }
}