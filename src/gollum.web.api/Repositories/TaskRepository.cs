using System;
using System.Collections.Generic;
using gollum.web.common.Models.Task;
using System.Collections.Concurrent;

namespace gollum.web.api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        static ConcurrentDictionary<string, TaskModel> tasks = new ConcurrentDictionary<string, TaskModel>();

        public TaskRepository()
        {
            Add(new TaskModel
            {
                Name = "TaskForOrganization",
                Key = Guid.NewGuid(),
                Description = "Task Description A",
                Tags = new string[] { "task tag 1", "task tag 2", "task tag 3" }
            });
            Add(new TaskModel
            {
                Name = "TaskForPersonalUser",
                Key = Guid.NewGuid(),
                Description = "Task Description B",
                Tags = new string[] { "task tag 1", "task tag 2", "task tag 5", "task tag 6", "task tag 8" }
            });
        }

        public void Add(TaskModel item)
        {
            item.Id = Guid.NewGuid().ToString();
            tasks[item.Id] = item;
        }

        public TaskModel Delete(string key)
        {
            TaskModel item;
            tasks.TryGetValue(key, out item);
            tasks.TryRemove(key, out item);
            return item;
        }

        public TaskModel Get(string key)
        {
            TaskModel item;
            tasks.TryGetValue(key, out item);
            return item;
        }

        public IEnumerable<TaskModel> GetAll()
        {
            return tasks.Values;
        }

        public void Update(TaskModel item)
        {
            tasks[item.Id] = item;
        }
    }
}