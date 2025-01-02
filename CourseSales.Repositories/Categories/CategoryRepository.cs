using Microsoft.EntityFrameworkCore;

namespace CourseSales.Repositories.Categories
{
    public class CategoryRepository(CourseSalesDbContext context) : GenericRepository<Category>(context), ICategoryRepository
    {
        public Task<Category?> GetCategoryWithCoursesAsync(int id)
        {
           return context.Categories.Include(x => x.Courses).FirstOrDefaultAsync(x => x.Id == id);
             
        }

        public IQueryable<Category> GetCategoryByCoursesAsync()
        {
            return context.Categories.Include(x => x.Courses).AsQueryable();
        }
    }
}
