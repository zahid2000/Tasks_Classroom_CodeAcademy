using System.Linq.Expressions;

namespace MyContact.Core.DataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity:class,new()
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter=null);
        TEntity Get (Expression<Func<TEntity,bool>> filter);
    }
}