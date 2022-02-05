using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using Tabloid.Domain.Entities;
using Tabloid.Infrastructure.Repositories.Interfaces;

namespace Tabloid.Infrastructure.Repositories.Implementations
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        protected readonly TabDbContext _context;

        public Repository(TabDbContext context)
        {
            _context = context;
        }

        public async virtual Task<TEntity> FindById(TId id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async virtual Task<ICollection<TEntity>> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = _context
                .Set<TEntity>()
                .AsQueryable();

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            if (include is not null)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }

        public async virtual Task Insert(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<bool> Contains(TEntity entity)
        {
            return await _context
                .Set<TEntity>()
                .ContainsAsync(entity);
        }
    }
}
