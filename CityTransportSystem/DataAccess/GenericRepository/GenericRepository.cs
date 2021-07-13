using DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        protected virtual DbSet<TEntity> DbSet
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

        public virtual async Task<TEntity> GetAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            TEntity item = await DbSet.FindAsync(entity);
            UpdateEntity(item);
        }
        protected virtual void UpdateEntity(TEntity entityToUpdate)
        {
            if (_dbContext.Entry(entityToUpdate).State == EntityState.Detached)
            {
                DbSet.Attach(entityToUpdate);
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task DeleteAsync(object id)
        {
            TEntity item = await DbSet.FindAsync(id);
            DeleteEntity(item);
        }

        protected virtual void DeleteEntity(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }
    }
}
