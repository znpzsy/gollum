using gollum.web.common.Models.Role;

//encapsulates the data layer, and contains logic for retrieving data and mapping it to a model.
namespace gollum.web.api.Repositories.Role
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public interface IRoleRepository : IBaseApplicationRepository<RoleModel>
    {
    }
}
