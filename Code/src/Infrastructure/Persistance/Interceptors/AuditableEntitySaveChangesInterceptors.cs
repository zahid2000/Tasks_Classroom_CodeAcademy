
using Code.Domain.Common;

namespace Code.Infrastructure.Persistance.Interceptors
{
    public class AuditableEntitySaveChangesInterceptors : SaveChangesInterceptor
    {
        private readonly IDateTime _dateTime;
        public AuditableEntitySaveChangesInterceptors(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext? context)
        {
            if (context == null) return;
            
            foreach(var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (entry.State==EntityState.Added)
                {
                    entry.Entity.CreatedDate = _dateTime.Now;
                    entry.Entity.CreatedBy = "User Info";
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModified = _dateTime.Now;
                    entry.Entity.LastModifiedBy = "User Info";
                }
            }
        }
    }
}
