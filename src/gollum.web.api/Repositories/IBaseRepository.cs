using System.Collections.Generic;

namespace gollum.web.api.Repositories
{
    // ...basic CRUD operations have to be implemented for all.
    public interface IBaseRepository<TModel>
    {
        void Add(TModel item);
        IEnumerable<TModel> GetAll();
        TModel Get(string key);
        TModel Delete(string key);
        void Update(TModel item);
    }
}
