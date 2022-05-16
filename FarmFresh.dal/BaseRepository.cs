using FarmFresh.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : class
    {
        protected readonly DbSet<TEntity> dbSet;
        protected readonly FarmFreshDbContext _context;

        public BaseRepository(FarmFreshDbContext context)
        {
            _context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        //public async Task<TEntity> GetByIdAsync(Guid id)
        //{
        //    return await _context.Set<TEntity>().FindAsync(id);
        //}

        public async Task Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
