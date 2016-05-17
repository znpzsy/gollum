using gollum.web.api.Repositories.User;
using gollum.web.common.Models.User;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace gollum.web.api.Controllers
{
    /// <summary>
    /// Controller for Users
    /// </summary>
    /// <remarks>Users are globally defined.</remarks>

    [RoutePrefix("api/v1/User")]
    public class UserController : ApiController
    {

        #region Fields

        private readonly IUserRepository repo;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public UserController(IUserRepository repository)
        {
            //repo will be reaching out to the data access layer.
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
        public IEnumerable<UserModel> GetAll()
        {
            return repo.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("{userId}")]
        [HttpGet]
        public UserModel GetById(Guid userId)
        {
            var item = repo.Get(userId);
            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route]
        [HttpPost]
        public IHttpActionResult Create([FromBody]UserModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            repo.Add(model);
            return Created<UserModel>(string.Format("{0}/{1}", Request.RequestUri.ToString().TrimEnd(new char[] { '/' }), model.Id), model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route]
        [HttpPut]
        public IHttpActionResult Put(Guid userId, [FromBody]UserModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var User = repo.Get(userId);
            if (User == null)
            {
                return NotFound();
            }

            repo.Update(item);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        [Route]
        [HttpDelete]
        public void Delete(Guid userId)
        {
            repo.Delete(userId);
        }

        #endregion

    }
}
