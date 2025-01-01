namespace CourseSales.Repositories.Courses
{
    public interface ICourseRepository:IGenericRepository<Course>
    {
        public Task<List<Course>> GetTopPriceCourseAsync(int count);
    }
        
    
}
