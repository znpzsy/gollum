using System;
using System.Collections.Generic;

namespace gollum.web.api.Repositories
{
    /// <summary>
    /// Base Repository for all Global Objects
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IBaseGlobalRepository<TModel> : IBaseRepository
    {
        /// <summary>
        /// Adds a globally defined object 
        /// (As 'User', independent of application defn, exists in global)
        /// </summary>
        /// <returns>The created TModel </returns>
        /// <param name="model">TModel</param>
        TModel Add(TModel model);

        /// <summary>
        /// Gets all (globally defined) entities of type TModel
        /// </summary>
        /// <returns>A list of the TModel</returns>
        IEnumerable<TModel> GetAll();

        /// <summary>
        /// Gets a specific (globally defined) entity of type TModel
        /// </summary>
        /// <param name="objId">Object Id</param>
        /// <returns>TModel</returns>
        TModel Get(Guid objId);

        /// <summary>
        /// Deletes a specific (globally defined) entity of type TModel
        /// </summary>
        /// <param name="objId"></param>
        void Delete(Guid objId);

        /// <summary>
        /// Updates a specific (globally defined) entity of type TModel
        /// </summary>
        /// <param name="model"></param>
        void Update(TModel model);
    }
}
