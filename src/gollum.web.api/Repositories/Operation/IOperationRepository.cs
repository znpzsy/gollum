using gollum.web.common.Models.Operation;

//encapsulates the data layer, and contains logic for retrieving data and mapping it to a model.
namespace gollum.web.api.Repositories.Operation
{
    public interface IOperationRepository : IBaseApplicationRepository<OperationModel>
    {
    }
}
