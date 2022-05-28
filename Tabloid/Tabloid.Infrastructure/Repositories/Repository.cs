using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Context;

namespace Tabloid.Infrastructure.Repositories
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        protected readonly TabDbContext _context;

        public Repository(TabDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> FindById(TId id)
        {
            return await _context
                .Set<TEntity>()
                .FindAsync(id);
        }

        public virtual async Task<ICollection<TEntity>> GetAll()
        {
            return await _context
                .Set<TEntity>()
                .AsQueryable()
                .ToListAsync();
        }

        public virtual async Task Insert(TEntity entity)
        {
            await _context
                .Set<TEntity>()
                .AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _context
                .Set<TEntity>()
                .Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _context
                .Set<TEntity>()
                .Remove(entity);
        }

        public virtual async Task<bool> Contains(TEntity entity)
        {
            return await _context
                .Set<TEntity>()
                .ContainsAsync(entity);
        }
    }
}
