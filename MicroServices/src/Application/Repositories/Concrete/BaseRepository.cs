namespace Application.Repositories.Concrete;

public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : BaseEntity, new()
    where TContext : DbContext,new()
{
    private readonly TContext context;

    public BaseRepository(TContext context)
    {
        this.context = context;
    }

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
          context.Entry(entity).State=EntityState.Added;
             await context.SaveChangesAsync(cancellationToken);
        return entity;
         
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
          context.Entry(entity).State = EntityState.Deleted;
             await context.SaveChangesAsync(cancellationToken);
       
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken,Expression<Func<TEntity, bool>>? filter = null)
    {
        
            return filter == null
                ?await context.Set<TEntity>().ToListAsync(cancellationToken)
                :await context.Set<TEntity>().Where(filter).ToListAsync(cancellationToken);
        
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
    {
        return await context.Set<TEntity>().Where(filter).SingleOrDefaultAsync(cancellationToken);
    }
}
