using DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;

        private DbSet<TEntity> entity;

        public GenericRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        protected virtual DbSet<TEntity> Table
        {
            get
            {
                if (entity is null)
                {
                    entity = _dbContext.Set<TEntity>();
                }
                return entity;
            }
        }

        public virtual TEntity Get(object id)
        {
            return Table.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Table.ToList();
        }

        public virtual void Add(TEntity entity)
        {
            Table.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Table.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity entity = Table.Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                Table.Attach(entityToDelete);
            }
            Table.Remove(entityToDelete);
        }
    }
}
