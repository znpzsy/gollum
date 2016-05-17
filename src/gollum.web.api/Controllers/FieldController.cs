using gollum.web.api.Repositories.Field;
using gollum.web.common.Models.Field;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace gollum.web.api.Controllers
{
    /// <summary>
    /// Controller for Fields.
    /// </summary>
    /// 
    [RoutePrefix("api/v1/Application/{applicationId}/Field")]
    public class FieldController : ApiController
    {

        #region Fields

        private readonly IFieldRepository repo;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor of the FieldController
        /// </summary>
        /// <remarks>Repo will be reaching out to the data access layer.</remarks>
        /// <param name="repository"></param>
        public FieldController(IFieldRepository repository)
        {
            this.repo = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId">Application Id - Refers to the Id of the <see cref="gollum.web.common.Models.Application.ApplicationModel"/> object. </param>
        /// <returns></returns>
        [Route]
        [HttpGet]
        public IEnumerable<FieldModel> GetAll(Guid applicationId)
        {
            return repo.GetAll(applicationId);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId">Application Id - Refers to the Id of the <see cref="gollum.web.common.Models.Application.ApplicationModel"/> object. </param>
        /// <param name="fieldId">Field Id - Refers to the Id of the <see cref="gollum.web.common.Models.Field.FieldModel"/> object. </param>
        /// <returns></returns>
        [Route("{fieldId}")]
        [HttpGet]
        public FieldModel GetById(Guid applicationId, Guid fieldId)
        {
            var item = repo.Get(applicationId, fieldId);
            return item;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId">Application Id - Refers to the Id of the <see cref="gollum.web.common.Models.Application.ApplicationModel"/> object. </param>
        /// <param name="model">Field Id - Refers to the <see cref="gollum.web.common.Models.Field.FieldModel"/> object. </param>
        /// <returns></returns>
        [Route]
        [HttpPost]
        public IHttpActionResult Create(Guid applicationId, [FromBody]FieldModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            repo.Add(applicationId, model);
            return Created<FieldModel>(string.Format("{0}/{1}", Request.RequestUri.ToString().TrimEnd(new char[] { '/' }), model.Id), model);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId">Application Id - Refers to the Id of the <see cref="gollum.web.common.Models.Application.ApplicationModel"/> object. </param>
        /// <param name="fieldId">Field Id - Refers to the Id of the <see cref="gollum.web.common.Models.Field.FieldModel"/> object. </param>
        /// <param name="model">Field Id - Refers to the <see cref="gollum.web.common.Models.Field.FieldModel"/> object. </param>
        /// <returns></returns>
        [Route]
        [HttpPut]
        public IHttpActionResult Put(Guid applicationId, Guid fieldId, [FromBody]FieldModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var Field = repo.Get(applicationId, fieldId);
            if (Field == null)
            {
                return NotFound();
            }

            repo.Update(applicationId, model);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId">Application Id - Refers to the Id of the <see cref="gollum.web.common.Models.Application.ApplicationModel"/> object. </param>
        /// <param name="fieldId">Field Id - Refers to the Id of the <see cref="gollum.web.common.Models.Field.FieldModel"/> object. </param>
        [Route]
        [HttpDelete]
        public void Delete(Guid applicationId, Guid fieldId)
        {
            repo.Delete(applicationId, fieldId);
        }

        #endregion

    }
}
