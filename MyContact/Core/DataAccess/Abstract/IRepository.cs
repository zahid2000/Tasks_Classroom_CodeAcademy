using MyContact.Core.Entities;
using System.Linq.Expressions;

namespace MyContact.Core.DataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity:class, IEntity, new()
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter=null);
        TEntity Get(TEntity entity);
        TEntity Get (Expression<Func<TEntity,bool>> filter);
    }
    public interface IAsyncRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
       
    }
    

}