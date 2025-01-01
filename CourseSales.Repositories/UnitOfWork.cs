namespace CourseSales.Repositories
{
    public class UnitOfWork(CourseSalesDbContext context) : IUnitOfWork
    {
        public Task<int> SaveChangeAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
