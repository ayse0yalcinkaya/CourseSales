namespace CourseSales.Service.Courses
{
    public interface ICourseService
    {
        Task<ServiceResult<List<CourseDto>>> GetTopPriceCourseAsync(int count);
    }
}
