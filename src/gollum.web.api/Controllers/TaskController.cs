using gollum.web.api.Repositories;
using gollum.web.common.Models.Task;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace gollum.web.api.Controllers
{
    public class TaskController : ApiController
    {
        private readonly ITaskRepository repo;
        public TaskController(ITaskRepository repository)
        {
            //repo will be reaching out to the data access layer.
            this.repo = repository;
        }

        //// GET: api/Task
        [HttpGet]
        public IEnumerable<TaskModel> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/Task/5
        // http://stackoverflow.com/a/23412189
        [HttpGet]
        public TaskModel GetById(Guid id)
        {
            var item = repo.Get(id.ToString());
            return item;
        }

        // POST: api/Task
        [HttpPost]
        public IHttpActionResult Create([FromBody]TaskModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            repo.Add(model);
            return Created<TaskModel>(string.Format("{0}/{1}", Request.RequestUri.ToString().TrimEnd(new char[]{'/' }), model.Id), model);
        }

        // PUT: api/Task/5
        [HttpPut]
        public IHttpActionResult Put(Guid id, [FromBody]TaskModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var task = repo.Get(id.ToString());
            if (task == null)
            {
                return NotFound();
            }

            repo.Update(item);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: api/Task/5
        [HttpDelete]
        public void Delete(Guid id)
        {
            repo.Delete(id.ToString());
        }
    }
}
