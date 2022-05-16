using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Interfaces.IRepositories
{
    public interface IRepository<TEntity, TKeyType> where TEntity : class
    {
        //Task<TEntity> GetByIdAsync(TKeyType id);

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        int Complete();
    }
}
