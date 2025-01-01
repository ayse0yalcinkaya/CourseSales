using Microsoft.EntityFrameworkCore;

namespace CourseSales.Repositories.Courses
{
    internal class CourseRepository(CourseSalesDbContext context) : GenericRepository<Course>(context), ICourseRepository
    {
        public Task<List<Course>> GetTopPriceCourseAsync(int count)
        {
            return Context.Courses.OrderByDescending(x => x.Price).Take(count).ToListAsync();
        }
    }
}
 