using System;
using System.Collections.Generic;
using gollum.web.common.Models.Task;
using System.Collections.Concurrent;

namespace gollum.web.api.Repositories.Task
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        #region Fields

        static ConcurrentDictionary<string, TaskModel> tasks = new ConcurrentDictionary<string, TaskModel>();

        #endregion

        #region Constructor

        /// <summary>
        /// Repository Constructor
        /// </summary>
        public TaskRepository()
        {
            Add(Guid.NewGuid(), new TaskModel
            {
                Name = "TaskForOrganization",
                Key = Guid.NewGuid(),
                Description = "Task Description A",
                Tags = new string[] { "task tag 1", "task tag 2", "task tag 3" }
            });
            Add(Guid.NewGuid(), new TaskModel
            {
                Name = "TaskForPersonalUser",
                Key = Guid.NewGuid(),
                Description = "Task Description B",
                Tags = new string[] { "task tag 1", "task tag 2", "task tag 5", "task tag 6", "task tag 8" }
            });
        }


        #endregion

        #region Methods

        #endregion

        /// <summary>
        /// Add new Task to TaskRepo
        /// </summary>
        /// <param name="applicationId">Id of the application</param>
        /// <param name="model">Id of the Task Model</param>
        /// <returns></returns>
        public TaskModel Add(Guid applicationId, TaskModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            tasks[model.Id] = model;

            return model;
        }

        /// <summary>
        /// Delete Task from TaskRepo
        /// </summary>
        /// <param name="applicationId">Id of the application</param>
        /// <param name="objId">Id of the Task Model</param>
        public void Delete(Guid applicationId, Guid objId)
        {
            TaskModel item;
            string key = objId.ToString();
            tasks.TryGetValue(key, out item);
            tasks.TryRemove(key, out item);
        }

        /// <summary>
        /// Get single Task from the repository, specified by the task Id, belonging to an application
        /// </summary>
        /// <param name="applicationId">Id of the application</param>
        /// <param name="objId">Id of the Task Model</param>
        /// <returns></returns>
        public TaskModel Get(Guid applicationId, Guid objId)
        {
            TaskModel item;
            tasks.TryGetValue(objId.ToString(), out item);
            return item;
        }

        /// <summary>
        /// Get all TaskModels belonging to the Application specified
        /// </summary>
        /// <param name="applicationId">Id of the application</param>
        /// <returns></returns>
        public IEnumerable<TaskModel> GetAll(Guid applicationId)
        {
            return tasks.Values;
        }

        /// <summary>
        /// Update single TaskModel, belonging to the application specified.
        /// </summary>
        /// <param name="applicationId">Id of the application</param>
        /// <param name="model">Task Model</param>
        public void Update(Guid applicationId, TaskModel model)
        {
            tasks[model.Id] = model;
        }
    }
}