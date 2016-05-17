using gollum.web.api.Repositories.Task;
using gollum.web.common.Models.Task;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace gollum.web.api.Controllers
{
    // http://stackoverflow.com/a/23412189


    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/v1/Application/{applicationId}/Task")]
    public class TaskController : ApiController
    {
        #region Fields

        private readonly ITaskRepository repo;

        #endregion

        #region Constructors

        /// <summary>
        /// Task Controller initialized with injected params.
        /// </summary>
        /// <param name="repository">Task Repo</param>
        public TaskController(ITaskRepository repository)
        {
            //repo will be reaching out to the data access layer.
            this.repo = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the all tasks.
        /// </summary>
        /// <returns>A contact record with an HTTP 200, or null with an HTTP 404.</returns>
        /// <param name="applicationId"></param>
        /// <response code="200">OK</response>
        [Route]
        [HttpGet]
        public IEnumerable<TaskModel> GetAll(Guid applicationId)
        {
            return repo.GetAll(applicationId);
        }


        /// <summary>
        /// Gets the details of the task (specified by taskId)
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [Route("{taskId}")]
        [HttpGet]
        public TaskModel GetById(Guid applicationId, Guid taskId)
        {
            var item = repo.Get(applicationId, taskId);
            return item;
        }

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="model"></param>
        /// <returns>Returns the URI of the task created.</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        [Route]
        [HttpPost]
        public IHttpActionResult Create(Guid applicationId, [FromBody]TaskModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            repo.Add(applicationId, model);
            return Created<TaskModel>(string.Format("{0}/{1}", Request.RequestUri.ToString().TrimEnd(new char[] { '/' }), model.Id), model);
        }

        /// <summary>
        /// Updates the specified task.
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="taskId">The guid of the related task.</param>
        /// <param name="model"></param>
        /// <returns>A task record is updated with an HTTP 204. If the record is not found, the response will be HTTP 404. If the request body does not contain the task model, the response will be HTTP 400.</returns>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [Route("{taskId}")]
        [HttpPut]
        public IHttpActionResult Put(Guid applicationId, Guid taskId, [FromBody]TaskModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var task = repo.Get(applicationId, taskId);
            if (task == null)
            {
                return NotFound();
            }

            repo.Update(applicationId, model);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Deletes the Task, specified by taskId
        /// </summary>
        /// <returns>A task record is deleted with an HTTP 204. If the record is not found, the response will be HTTP 404.</returns>
        /// <param name="applicationId"></param>
        /// <param name="taskId">The guid of the related task.</param>
        /// <response code="204">No Content</response>
        /// <response code="404">Not Found</response>
        [Route("{taskId}")]
        [HttpDelete]
        public IHttpActionResult Delete(Guid applicationId, Guid taskId)
        {
            var task = repo.Get(applicationId, taskId);
            if (task == null)
            {
                return NotFound();
            }

            repo.Delete(applicationId, taskId);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        #endregion

    }
}
