using AutoMapper;
using CourseSales.Repositories;
using CourseSales.Repositories.Courses;
using CourseSales.Service.Courses.Create;
using CourseSales.Service.Courses.Update;
using CourseSales.Service.Courses.UpdateStock;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CourseSales.Service.Courses
{
    public class CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork,
        IValidator<CreateCourseRequest> createCourseRequestValidator, IMapper mapper) : ICourseService
    {
        public async Task<ServiceResult<List<CourseDto>>> GetTopPriceCourseAsync(int count)
        {
            var courses = await courseRepository.GetTopPriceCourseAsync(count);

            //var coursesAsDto = courses.Select(c => new CourseDto(c.Id, c.Name, c.Price, c.Stock)).ToList();

            var coursesAsDto = mapper.Map<List<CourseDto>>(courses);

            return new ServiceResult<List<CourseDto>>()
            {
                Data = coursesAsDto
            };

        }

        public async Task<ServiceResult<List<CourseDto>>> GetAllListAsync()
        {
            var courses = await courseRepository.GetAll().ToListAsync();

        //  var coursesAsDto = courses.Select(c => new CourseDto(c.Id, c.Name, c.Price, c.Stock)).ToList(); //manuel mapping
            var coursesAsDto = mapper.Map<List<CourseDto>>(courses);
            return ServiceResult<List<CourseDto>>.Success(coursesAsDto);
        }

        public async Task<ServiceResult<List<CourseDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            int skip = (pageNumber - 1) * pageSize;
            var courses = await courseRepository.GetAll().Skip(skip).Take(pageSize).ToListAsync();

            //var coursesAsDto = courses.Select(c => new CourseDto(c.Id, c.Name, c.Price, c.Stock)).ToList(); //manuel mapping
            var coursesAsDto = mapper.Map<List<CourseDto>>(courses);


            return ServiceResult<List<CourseDto>>.Success(coursesAsDto);
        }
        public async Task<ServiceResult<CourseDto?>> GetByIdAsync(int id)
        {
            var course = await courseRepository.GetByIdAsync(id);

            if (course is null)
            {
               return ServiceResult<CourseDto?>.Fail("Course not found", HttpStatusCode.NotFound);
            }

            //var courseAsDto = new CourseDto(course!.Id, course.Name, course.Price, course.Stock);
            var courseAsDto = mapper.Map<CourseDto>(course);


            return ServiceResult<CourseDto>.Success(courseAsDto)!;

        }
         
        public async Task<ServiceResult<CreateCourseResponse>> CreateAsync(CreateCourseRequest request)
        {
            //throw new CriticalException("Kritik seviye bir hata meydana geldi");
            //throw new Exception("db hatası");

            var anyCourse = await courseRepository.Where(x => x.Name == request.Name).AnyAsync();
            if (anyCourse)
            {
                return ServiceResult<CreateCourseResponse>.Fail("Kurs ismi veritabanında bulunmaktadır", 
                    HttpStatusCode.NotFound);
            }
            //async manuel fluent validation business check
            //var validationResult = await createCourseRequestValidator.ValidateAsync(request);
            //if (!validationResult.IsValid)
            //{
            //    return ServiceResult<CreateCourseResponse>.Fail(
            //        validationResult.Errors.Select(x => x.ErrorMessage).ToList());

            //}


            //var course = new Course()
            //{
            //    Name = request.Name,
            //    Price = request.Price,
            //    Stock = request.Stock,
            //};
            var course = mapper.Map<Course>(request);

            await courseRepository.AddAsync(course);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult<CreateCourseResponse>.SuccessAsCreated(new CreateCourseResponse(course.Id),
                $"api/courses/{course.Id}");

        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateCourseRequest request)
        {
            // FluentValidation doğrulaması
            //var validator = new UpdateCourseRequestValidator();
            //var validationResult = await validator.ValidateAsync(request);

            //if (!validationResult.IsValid)
            //{
            //    return ServiceResult.Fail(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            //}

            //var course = await courseRepository.GetByIdAsync(id);

            //if (course is null)
            //{
            //    return ServiceResult.Fail("Güncellenecek kurs bulunamadı.", HttpStatusCode.NotFound);
            //}



            var isCourseNameExist = 
                await courseRepository.Where(x => x.Name == request.Name && x.Id != id).AnyAsync();

            if (isCourseNameExist)
            {
                return ServiceResult.Fail("Kurs ismi veritabanında bulunmaktadır", HttpStatusCode.BadRequest);
            }

            //course.Name = request.Name;
            //course.Price = request.Price;
            //course.Stock = request.Stock;

            var course = mapper.Map<Course>(request);
            course.Id = id;
                

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
