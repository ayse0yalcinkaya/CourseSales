using CourseSales.Repositories;
using CourseSales.Repositories.Courses;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http.Headers;
using FluentValidation;


namespace CourseSales.Service.Courses
{
    public class CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork, 
        IValidator<CreateCourseRequest> createCourseRequestValidator): ICourseService
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

        public async Task<ServiceResult<List<CourseDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            int skip = (pageNumber - 1)*pageSize;
            var courses = await courseRepository.GetAll().Skip(skip).Take(pageSize).ToListAsync();
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
            //var anyCourse = await courseRepository.Where(x => x.Name == request.Name).AnyAsync();
            //if (anyCourse)
            //{
            //    return ServiceResult<CreateCourseResponse>.Fail("Kurs ismi veritabanında bulunmaktadır", HttpStatusCode.BadRequest);
            //}
            var validationResult = await createCourseRequestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return ServiceResult<CreateCourseResponse>.Fail(
                    validationResult.Errors.Select(x => x.ErrorMessage).ToList());
                
            }


            var course = new Course()
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
            };
            
            await courseRepository.AddAsync(course);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult<CreateCourseResponse>.SuccessAsCreated(new CreateCourseResponse(course.Id), 
                $"api/courses/{course.Id}");

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

        public async Task<ServiceResult> UpdateStockAsync(UpdateCourseStockRequest request)
        {
            var course = await courseRepository.GetByIdAsync(request.CourseId);
            if (course is null)
            {
                return ServiceResult.Fail("Course not found", HttpStatusCode.NotFound);
            }

            course.Stock = request.Quantity;
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
