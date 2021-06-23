using DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccess.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;
        private DbSet<TEntity> _entity;
        public GenericRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        public virtual TEntity Get(object id)
        {
            return Entity.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Entity;
        }
        public virtual void Add(TEntity entity)
        {
            Entity.Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            Entity.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(object id)
        {
            TEntity entity = Entity.Find(id);
            Delete(entity);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                Entity.Attach(entityToDelete);
            }
            Entity.Remove(entityToDelete);
        }
        protected virtual DbSet<TEntity> Entity
        {
            get
            {
                if (_entity is null)
                {
                    _entity = _dbContext.Set<TEntity>();
                }
                return _entity;
            }
        }
    }
}
