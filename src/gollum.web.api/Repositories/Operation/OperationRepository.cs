using System;
using System.Collections.Generic;
using gollum.web.common.Models.Operation;
using System.Collections.Concurrent;

namespace gollum.web.api.Repositories.Operation
{
    public class OperationRepository : IOperationRepository
    {
        static ConcurrentDictionary<string, OperationModel> Operations = new ConcurrentDictionary<string, OperationModel>();

        public OperationRepository()
        {
            Add(Guid.NewGuid(), new OperationModel
            {
                Name = "OperationForOrganization",
                Key = Guid.NewGuid(),
                Description = "Operation Description A",
                Tags = new string[] { "Operation tag 1", "Operation tag 2", "Operation tag 3" }
            });
            Add(Guid.NewGuid(), new OperationModel
            {
                Name = "OperationForPersonalUser",
                Key = Guid.NewGuid(),
                Description = "Operation Description B",
                Tags = new string[] { "Operation tag 1", "Operation tag 2", "Operation tag 5", "Operation tag 6", "Operation tag 8" }
            });
        }

        public OperationModel Add(Guid applicationId, OperationModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid applicationId, Guid objId)
        {
            throw new NotImplementedException();
        }

        public OperationModel Get(Guid applicationId, Guid objId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OperationModel> GetAll(Guid applicationId)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid applicationId, OperationModel model)
        {
            throw new NotImplementedException();
        }
    }
}