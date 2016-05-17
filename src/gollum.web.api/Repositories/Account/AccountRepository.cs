using System;
using System.Collections.Generic;
using gollum.web.common.Models.Account;
using System.Collections.Concurrent;

namespace gollum.web.api.Repositories.Account
{
    public class AccountRepository : IAccountRepository
    {
        static ConcurrentDictionary<string, AccountModel> Accounts = new ConcurrentDictionary<string, AccountModel>();

        public AccountRepository()
        {
            Add(Guid.NewGuid(), new AccountModel
            {
                Name = "AccountForOrganization",
                Key = Guid.NewGuid(),
                Description = "Account Description A",
                Tags = new string[] { "Account tag 1", "Account tag 2", "Account tag 3" }
            });
            Add(Guid.NewGuid(), new AccountModel
            {
                Name = "AccountForPersonalUser",
                Key = Guid.NewGuid(),
                Description = "Account Description B",
                Tags = new string[] { "Account tag 1", "Account tag 2", "Account tag 5", "Account tag 6", "Account tag 8" }
            });
        }

        public AccountModel Add(Guid applicationId, AccountModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid applicationId, Guid objId)
        {
            throw new NotImplementedException();
        }

        public AccountModel Get(Guid applicationId, Guid objId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountModel> GetAll(Guid applicationId)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid applicationId, AccountModel model)
        {
            throw new NotImplementedException();
        }
    }
}