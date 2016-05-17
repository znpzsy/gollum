using gollum.web.api.Repositories.Operation;
using gollum.web.common.Models.Operation;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace gollum.web.api.Controllers
{

    /// <summary>
    /// Controller for Operation CRUD
    /// </summary>
    [RoutePrefix("api/v1/Application/{applicationId}/Operation")]
    public class OperationController : ApiController
    {

        #region Fields

        private readonly IOperationRepository repo;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor of the OperationController
        /// </summary>
        /// <remarks>Repo will be reaching out to the data access layer.</remarks>
        /// <param name="repository"></param>
        public OperationController(IOperationRepository repository)
        {

            this.repo = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        [Route]
        [HttpGet]
        public IEnumerable<OperationModel> GetAll(Guid applicationId)
        {
            return repo.GetAll(applicationId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="operationId"></param>
        /// <returns></returns>
        [Route("{operationId}")]
        [HttpGet]
        public OperationModel GetById(Guid applicationId, Guid operationId)
        {
            var item = repo.Get(applicationId, operationId);
            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route]
        [HttpPost]
        public IHttpActionResult Create(Guid applicationId, [FromBody]OperationModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            repo.Add(applicationId, model);
            return Created<OperationModel>(string.Format("{0}/{1}", Request.RequestUri.ToString().TrimEnd(new char[] { '/' }), model.Id), model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="operationId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route]
        [HttpPut]
        public IHttpActionResult Put(Guid applicationId, Guid operationId, [FromBody]OperationModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var Operation = repo.Get(applicationId, operationId);
            if (Operation == null)
            {
                return NotFound();
            }

            repo.Update(applicationId, model);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="operationId"></param>
        [Route]
        [HttpDelete]
        public void Delete(Guid applicationId, Guid operationId)
        {
            repo.Delete(applicationId, operationId);
        }
        #endregion

    }
}
