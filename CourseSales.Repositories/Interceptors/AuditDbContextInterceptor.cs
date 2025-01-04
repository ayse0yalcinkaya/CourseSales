using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CourseSales.Repositories.Interceptors
{
    public class AuditDbContextInterceptor:SaveChangesInterceptor
    {
        private static readonly Dictionary<EntityState, Action<DbContext, IAuditEntity>> Behaviors = new()
        {
            {EntityState.Added, AddBehavior },
            {EntityState.Modified, ModifiedBehavior }
        };

        private static void AddBehavior(DbContext context, IAuditEntity auditEntity)
        {
            auditEntity.Created = DateTime.Now;
            context.Entry(auditEntity).Property(x => x.Updated).IsModified = false;
        }

        private static void ModifiedBehavior(DbContext context, IAuditEntity auditEntity)
        {
            auditEntity.Updated = DateTime.Now;
            context.Entry(auditEntity).Property(x => x.Created).IsModified = false;
        }


        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, 
            InterceptionResult<int> result, 
            CancellationToken cancellationToken = default)
        {
            foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries().ToList())
            {
                if (entityEntry.Entity is not IAuditEntity auditEntry) continue;

                //_behaviors[entityEntry.State](eventData.Context, auditEntry);
                Behaviors[entityEntry.State](eventData.Context, auditEntry);

                #region 1. yol

                //switch (entityEntry.State)
                //    {
                //    case EntityState.Added:


                //        AddBehavior(eventData.Context, auditEntry);


                //        break;
                //    case EntityState.Modified:


                //        ModifiedBehavior(eventData.Context, auditEntry);


                //        break;
                //}

                #endregion

            }       

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
