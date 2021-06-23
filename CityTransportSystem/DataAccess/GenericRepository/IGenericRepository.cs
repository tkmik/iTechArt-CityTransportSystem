using System.Collections.Generic;

namespace DataAccess.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(object id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
    }
}
