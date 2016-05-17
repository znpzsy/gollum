using System;
using System.Collections.Generic;
using gollum.web.common.Models.Organization;
using System.Collections.Concurrent;

namespace gollum.web.api.Repositories.Organization
{
    public class OrganizationRepository : IOrganizationRepository
    {
        static ConcurrentDictionary<string, OrganizationModel> Organizations = new ConcurrentDictionary<string, OrganizationModel>();

        public OrganizationRepository()
        {
            Add(Guid.NewGuid(), new OrganizationModel
            {
                Name = "OrganizationForOrganization",
                Key = Guid.NewGuid(),
                Description = "Organization Description A",
                Tags = new string[] { "Organization tag 1", "Organization tag 2", "Organization tag 3" }
            });
            Add(Guid.NewGuid(), new OrganizationModel
            {
                Name = "OrganizationForPersonalUser",
                Key = Guid.NewGuid(),
                Description = "Organization Description B",
                Tags = new string[] { "Organization tag 1", "Organization tag 2", "Organization tag 5", "Organization tag 6", "Organization tag 8" }
            });
        }

        public OrganizationModel Add(Guid applicationId, OrganizationModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid applicationId, Guid objId)
        {
            throw new NotImplementedException();
        }

        public OrganizationModel Get(Guid applicationId, Guid objId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrganizationModel> GetAll(Guid applicationId)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid applicationId, OrganizationModel model)
        {
            throw new NotImplementedException();
        }
    }
}