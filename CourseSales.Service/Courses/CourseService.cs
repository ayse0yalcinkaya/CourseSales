using CourseSales.Repositories;
using CourseSales.Repositories.Courses;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http.Headers;


namespace CourseSales.Service.Courses
{
    public class CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork): ICourseService
    {
        public async Task<ServiceResult<List<CourseDto>>> GetTopPriceCourseAsync(int count)
        {
            var courses = await courseRepository.GetTopPriceCourseAsync(count);

            var coursesAsDto = courses.Select(c => new CourseDto(c.Id, c.Name, c.Price, c.Stock)).ToList();

            return new ServiceResult<List<CourseDto>>()
            {
                Data = coursesAsDto
            };

        }

        public async Task<ServiceResult<List<CourseDto>>> GetAllListAsync()
        {
            var courses = await courseRepository.GetAll().ToListAsync();
            var coursesAsDto = courses.Select(c => new CourseDto(c.Id, c.Name, c.Price, c.Stock)).ToList();
            return ServiceResult<List<CourseDto>>.Success(coursesAsDto);
        }
        public async Task<ServiceResult<CourseDto?>> GetByIdAsync(int id)
        {
            var course = await courseRepository.GetByIdAsync(id);

            if (course is null)
            {
                ServiceResult<CourseDto>.Fail("Course not found", System.Net.HttpStatusCode.NotFound);
            }

            var courseAsDto = new CourseDto(course!.Id, course.Name, course.Price, course.Stock);

            return ServiceResult<CourseDto>.Success(courseAsDto)!;

        }

        public async Task<ServiceResult<CreateCourseResponse>> CreateAsync(CreateCourseRequest request)
        {
            var course = new Course()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
            };
            
            await courseRepository.AddAsync(course);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult<CreateCourseResponse>.Success(new CreateCourseResponse(course.Id));

        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateCourseRequest request)
        {
            var course = await courseRepository.GetByIdAsync(id);
            
            if (course is null)
            {
                return ServiceResult.Fail("Course not found", HttpStatusCode.NotFound);
            }
            course.Name = request.Name;
            course.Price = request.Price;
            course.Stock = request.Stock;


            courseRepository.Update(course);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);

        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var course = await courseRepository.GetByIdAsync(id);
            if (course is null)
            {
                return ServiceResult.Fail("Course not found", HttpStatusCode.NotFound);
            }
            courseRepository.Delete(course);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

    }
}
