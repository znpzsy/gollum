using gollum.web.common.Models.Account;

//encapsulates the data layer, and contains logic for retrieving data and mapping it to a model.
namespace gollum.web.api.Repositories.Account
{
    public interface IAccountRepository : IBaseApplicationRepository<AccountModel>
    {
    }
}
