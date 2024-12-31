using CourseSales.Repositories.Courses;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CourseSales.Repositories
{
    public class CourseSalesDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
