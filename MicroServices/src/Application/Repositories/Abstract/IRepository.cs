namespace Application.Repositories.Abstract;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    Task<TEntity> CreateAsync(TEntity entity,CancellationToken cancellationToken);
    Task<TEntity> GetAsync(Expression<Func<TEntity,bool>> filter, CancellationToken cancellationToken);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken,Expression<Func<TEntity, bool>>? filter=null);

}
