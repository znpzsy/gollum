using gollum.web.api.Repositories.Account;
using gollum.web.common.Models.Account;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace gollum.web.api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/v1/Application/{applicationId}/Account")]
    public class AccountController : ApiController
    {
        #region Fields

        private readonly IAccountRepository repo;

        #endregion


        #region Constructors

        /// <summary>
        /// AccountController Constructor
        /// The <paramref name="repository"/> parameter takes IAccountRepository.
        /// </summary>
        /// <param name="repository">IAccountRepository <see cref="Repositories.Account.AccountRepository"/> for the implementation</param>
        public AccountController(IAccountRepository repository)
        {
            //repo will be reaching out to the data access layer.
            this.repo = repository;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Gets all accounts defined within a specific application's boundary.
        /// </summary>
        /// <remarks>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. </remarks>
        /// <param name="applicationId">Application Id - Refers to the Id of the <see cref="gollum.web.common.Models.Application.ApplicationModel"/> object. </param>
        /// <returns></returns>
        [Route]
        [HttpGet]
        public IEnumerable<AccountModel> GetAll(Guid applicationId)
        {
            return repo.GetAll(applicationId);
        }

        /// <summary>
        /// Gets a specific account by its Id
        /// </summary>
        /// <param name="applicationId">Application Id - Refers to the Id of the <see cref="gollum.web.common.Models.Application.ApplicationModel"/> object. </param>
        /// <param name="accountId">Account Id - Refers to the Id of the <see cref="gollum.web.common.Models.Account.AccountModel"/> object. </param>
        /// <returns></returns>
        [Route("{accountId}")]
        [HttpGet]
        public AccountModel GetById(Guid applicationId, Guid accountId)
        {
            var item = repo.Get(applicationId, accountId);
            return item;
        }


        /// <summary>
        /// Creates an account within the boundaries of an application.
        /// </summary>
        /// <param name="applicationId">Application Id - Refers to the Id of the <see cref="gollum.web.common.Models.Application.ApplicationModel"/> object. </param>
        /// <param name="model">model - Refers to the Id of the <see cref="gollum.web.common.Models.Account.AccountModel"/> object. </param>
        /// <returns></returns>
        [Route]
        [HttpPost]
        public IHttpActionResult Create(Guid applicationId, [FromBody]AccountModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            repo.Add(applicationId, model);
            return Created<AccountModel>(string.Format("{0}/{1}", Request.RequestUri.ToString().TrimEnd(new char[] { '/' }), model.Id), model);
        }


        /// <summary>
        /// Updates an account with the specified accountId, within the boundaries of an application.
        /// </summary>
        /// <param name="applicationId">Application Id - Refers to the Id of the <see cref="gollum.web.common.Models.Application.ApplicationModel"/> object. </param>
        /// <param name="accountId">Account Id - Refers to the Id of the <see cref="gollum.web.common.Models.Account.AccountModel"/> object. </param>
        /// <param name="model">model - Refers to the Id of the <see cref="gollum.web.common.Models.Account.AccountModel"/> object. </param>
        /// <returns></returns>
        [Route]
        [HttpPut]
        public IHttpActionResult Put(Guid applicationId, Guid accountId, [FromBody]AccountModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var Account = repo.Get(applicationId, accountId);
            if (Account == null)
            {
                return NotFound();
            }

            repo.Update(applicationId, model);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }


        /// <summary>
        /// Deletes an account with the specified accountId, within the boundaries of an application.
        /// </summary>
        /// <param name="applicationId">Application Id - Refers to the Id of the <see cref="gollum.web.common.Models.Application.ApplicationModel"/> object. </param>
        /// <param name="accountId">Account Id - Refers to the Id of the <see cref="gollum.web.common.Models.Account.AccountModel"/> object. </param>
        [Route]
        [HttpDelete]
        public void Delete(Guid applicationId, Guid accountId)
        {
            repo.Delete(applicationId, accountId);
        }

        #endregion
    }
}
