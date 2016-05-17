using gollum.web.common.Models.Task;

//encapsulates the data layer, and contains logic for retrieving data and mapping it to a model.
namespace gollum.web.api.Repositories.Task
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITaskRepository : IBaseApplicationRepository<TaskModel>
    {
    }
}
