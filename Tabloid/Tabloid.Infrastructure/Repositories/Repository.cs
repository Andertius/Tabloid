using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Tabloid.Application.Interfaces.Repositories;
using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure.Repositories
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        protected readonly TabDbContext _context;

        public Repository(TabDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> FindById(TId id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IList<TEntity>> GetAll(Expression filter = null, IQueryable include = null)
        {
            return await _context
                .Set<TEntity>()
                .Select(x => x)
                .ToListAsync();
        }

        public async Task Insert(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
