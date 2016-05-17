using gollum.web.api.Repositories.Application;
using gollum.web.common.Models.Application;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace gollum.web.api.Controllers
{
    /// <summary>
    /// Controller for the Applications, which are defined globally.
    /// </summary>
    [RoutePrefix("api/v1/Application")]
    public class ApplicationController : ApiController
    {
        #region Fields

        private readonly IApplicationRepository repo;

        #endregion

        #region Constructors

        /// <summary>
        ///  Constructor of the ApplicationController
        /// </summary>
        /// <remarks>Repo will be reaching out to the data access layer.</remarks>
        /// <param name="repository">Refers to the Id of the <see cref="ApplicationRepository"/> object. </param>
        public ApplicationController(IApplicationRepository repository)
        {
            this.repo = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route]
        [HttpGet]
        public IEnumerable<ApplicationModel> GetAll()
        {
            return repo.GetAll();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        [Route("{applicationId}")]
        [HttpGet]
        public ApplicationModel GetById(Guid applicationId)
        {
            var item = repo.Get(applicationId);
            return item;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route]
        [HttpPost]
        public IHttpActionResult Create([FromBody]ApplicationModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            repo.Add(model);
            return Created<ApplicationModel>(string.Format("{0}/{1}", Request.RequestUri.ToString().TrimEnd(new char[] { '/' }), model.Id), model);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route]
        [HttpPut]
        public IHttpActionResult Put(Guid applicationId, [FromBody]ApplicationModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var Application = repo.Get(applicationId);
            if (Application == null)
            {
                return NotFound();
            }

            repo.Update(model);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        [Route]
        [HttpDelete]
        public void Delete(Guid applicationId)
        {
            repo.Delete(applicationId);
        }

        #endregion
    }
}
