using gollum.web.api.Repositories.Organization;
using gollum.web.common.Models.Organization;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace gollum.web.api.Controllers
{
    /// <summary>
    /// Controller for Organizations.
    /// </summary>
    /// <remarks>Organizations are application specific objects.</remarks>
    [RoutePrefix("api/v1/Application/{applicationId}/Organization")]
    public class OrganizationController : ApiController
    {
        #region Fields

        private readonly IOrganizationRepository repo;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public OrganizationController(IOrganizationRepository repository)
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
        public IEnumerable<OrganizationModel> GetAll(Guid applicationId)
        {
            return repo.GetAll(applicationId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        [Route("{organizationId}")]
        [HttpGet]
        public OrganizationModel GetById(Guid applicationId, Guid organizationId)
        {
            var item = repo.Get(applicationId, organizationId);
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
        public IHttpActionResult Create(Guid applicationId, [FromBody]OrganizationModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            repo.Add(applicationId, model);
            return Created<OrganizationModel>(string.Format("{0}/{1}", Request.RequestUri.ToString().TrimEnd(new char[] { '/' }), model.Id), model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="organizationId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route]
        [HttpPut]
        public IHttpActionResult Put(Guid applicationId, Guid organizationId, [FromBody]OrganizationModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var Organization = repo.Get(applicationId, organizationId);
            if (Organization == null)
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
        /// <param name="organizationId"></param>
        [Route]
        [HttpDelete]
        public void Delete(Guid applicationId, Guid organizationId)
        {
            repo.Delete(applicationId, organizationId);
        }

        #endregion
    }
}
