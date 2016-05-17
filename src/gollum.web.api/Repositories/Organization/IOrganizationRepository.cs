using gollum.web.common.Models.Organization;

//encapsulates the data layer, and contains logic for retrieving data and mapping it to a model.
namespace gollum.web.api.Repositories.Organization
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public interface IOrganizationRepository : IBaseApplicationRepository<OrganizationModel>
    {
    }
}
