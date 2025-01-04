namespace CourseSales.Repositories.Courses
{
    public interface ICourseRepository:IGenericRepository<Course, int>
    {
        public Task<List<Course>> GetTopPriceCourseAsync(int count);
    }
        
    
}
