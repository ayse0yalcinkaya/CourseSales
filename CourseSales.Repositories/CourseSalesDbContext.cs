using CourseSales.Repositories.Courses;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CourseSales.Repositories.Categories;
using CourseSales.Repositories.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CourseSales.Repositories
{
    public class CourseSalesDbContext : IdentityDbContext<User,IdentityRole, string>
    {
        public CourseSalesDbContext(DbContextOptions<CourseSalesDbContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        public DbSet<Users.UserRefreshToken> UserRefreshTokens { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
