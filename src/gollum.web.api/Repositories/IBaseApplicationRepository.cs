using System;
using System.Collections.Generic;

namespace gollum.web.api.Repositories
{
    /// <summary>
    /// Base Repository for all Application-Specific Objects
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IBaseApplicationRepository<TModel> : IBaseRepository
    {

        /// <summary>
        /// Adds an application specific object.
        /// (As 'Operation', exists specifically within application boundaries, belongs to an application)
        /// </summary>
        /// <param name="applicationId">applicationId</param>
        /// <param name="model">TModel</param>
        /// <returns>The created TModel</returns>
        TModel Add(Guid applicationId, TModel model);

        /// <summary>
        ///  Gets all (application specific) entities of type TModel
        /// </summary>
        /// <param name="applicationId">applicationId</param>
        /// <returns>A list of the TModel</returns>
        IEnumerable<TModel> GetAll(Guid applicationId);

        /// <summary>
        /// Gets a specific (application specific) entity of type TModel, with the objId
        /// </summary>
        /// <param name="applicationId">applicationId</param>
        /// <param name="objId">objId</param>
        /// <returns></returns>
        TModel Get(Guid applicationId, Guid objId);

        /// <summary>
        /// Deletes a specific (application specific) entity of type TModel, with the objId
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="objId"></param>
        void Delete(Guid applicationId, Guid objId);

        /// <summary>
        /// Updates a specific (application specific) entity of type TModel, with the objId
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="model"></param>
        void Update(Guid applicationId, TModel model);
    }
}
