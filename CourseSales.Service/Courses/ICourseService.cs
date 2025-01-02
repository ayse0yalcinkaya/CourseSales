using CourseSales.Service.Courses.Create;
using CourseSales.Service.Courses.Update;

namespace CourseSales.Service.Courses
{
    public interface ICourseService
    {
        Task<ServiceResult<List<CourseDto>>> GetTopPriceCourseAsync(int count);
        Task<ServiceResult<List<CourseDto>>> GetAllListAsync();
        Task<ServiceResult<List<CourseDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<CourseDto?>> GetByIdAsync(int id);
        Task<ServiceResult<CreateCourseResponse>> CreateAsync(CreateCourseRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateCourseRequest request);
        Task<ServiceResult> UpdateStockAsync(UpdateCourseStockRequest request);
        Task<ServiceResult> DeleteAsync(int id);

    }
}
