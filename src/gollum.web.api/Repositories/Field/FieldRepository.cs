using System;
using System.Collections.Generic;
using gollum.web.common.Models.Field;
using System.Collections.Concurrent;

namespace gollum.web.api.Repositories.Field
{
    public class FieldRepository : IFieldRepository
    {
        static ConcurrentDictionary<string, FieldModel> Fields = new ConcurrentDictionary<string, FieldModel>();

        public FieldRepository()
        {
            Add(Guid.NewGuid(), new FieldModel
            {
                Name = "FieldForOrganization",
                Key = Guid.NewGuid(),
                Description = "Field Description A",
                Tags = new string[] { "Field tag 1", "Field tag 2", "Field tag 3" }
            });
            Add(Guid.NewGuid(), new FieldModel
            {
                Name = "FieldForPersonalUser",
                Key = Guid.NewGuid(),
                Description = "Field Description B",
                Tags = new string[] { "Field tag 1", "Field tag 2", "Field tag 5", "Field tag 6", "Field tag 8" }
            });
        }

        public FieldModel Add(Guid applicationId, FieldModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid applicationId, Guid objId)
        {
            throw new NotImplementedException();
        }

        public FieldModel Get(Guid applicationId, Guid objId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FieldModel> GetAll(Guid applicationId)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid applicationId, FieldModel model)
        {
            throw new NotImplementedException();
        }
    }
}