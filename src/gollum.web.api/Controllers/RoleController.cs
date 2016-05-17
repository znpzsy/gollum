using gollum.web.api.Repositories.Role;
using gollum.web.common.Models.Role;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace gollum.web.api.Controllers
{
    /// <summary>
    /// Controller for Roles
    /// </summary>
    /// <remarks>Roles are application specific objects.</remarks>
    [RoutePrefix("api/v1/Application/{applicationId}/Role")]
    public class RoleController : ApiController
    {

        #region Fields

        private readonly IRoleRepository repo;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public RoleController(IRoleRepository repository)
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
        public IEnumerable<RoleModel> GetAll(Guid applicationId)
        {
            return repo.GetAll(applicationId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [Route("{roleId}")]
        [HttpGet]
        public RoleModel GetById(Guid applicationId, Guid roleId)
        {
            var item = repo.Get(applicationId, roleId);
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
        public IHttpActionResult Create(Guid applicationId, [FromBody]RoleModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            repo.Add(applicationId, model);
            return Created<RoleModel>(string.Format("{0}/{1}", Request.RequestUri.ToString().TrimEnd(new char[] { '/' }), model.Id), model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="roleId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route]
        [HttpPut]
        public IHttpActionResult Put(Guid applicationId, Guid roleId, [FromBody]RoleModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var Role = repo.Get(applicationId, roleId);
            if (Role == null)
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
        /// <param name="roleId"></param>
        [Route]
        [HttpDelete]
        public void Delete(Guid applicationId, Guid roleId)
        {
            repo.Delete(applicationId, roleId);
        }

        #endregion

    }
}
