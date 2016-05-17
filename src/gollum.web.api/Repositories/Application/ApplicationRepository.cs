using System;
using System.Collections.Generic;
using gollum.web.common.Models.Application;
using System.Collections.Concurrent;

namespace gollum.web.api.Repositories.Application
{
    public class ApplicationRepository : IApplicationRepository
    {
        static ConcurrentDictionary<string, ApplicationModel> Applications = new ConcurrentDictionary<string, ApplicationModel>();

        public ApplicationRepository()
        {
            Add(new ApplicationModel
            {
                Name = "ApplicationForOrganization",
                Key = Guid.NewGuid(),
                Description = "Application Description A",
                Tags = new string[] { "Application tag 1", "Application tag 2", "Application tag 3" }
            });
            Add(new ApplicationModel
            {
                Name = "ApplicationForPersonalUser",
                Key = Guid.NewGuid(),
                Description = "Application Description B",
                Tags = new string[] { "Application tag 1", "Application tag 2", "Application tag 5", "Application tag 6", "Application tag 8" }
            });
        }

        public ApplicationModel Add(ApplicationModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid objId)
        {
            throw new NotImplementedException();
        }

        public ApplicationModel Get(Guid objId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationModel model)
        {
            throw new NotImplementedException();
        }
    }
}