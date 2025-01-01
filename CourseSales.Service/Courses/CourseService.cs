using CourseSales.Repositories;
using CourseSales.Repositories.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Service.Courses
{
    public class CourseService(ICourseRepository courseRepository): ICourseService
    {
        public async Task<ServiceResult<List<Course>>> GetTopPriceCourseAsync(int count)
        {
            var courses = await courseRepository.GetTopPriceCourseAsync(count);
            return new ServiceResult<List<Course>>()
            {
                Data = courses
            };

        }

        public async Task<ServiceResult<Course>> GetCourseByIdAsync(int id)
        {
            var course = await courseRepository.GetByIdAsync(id);

            if (course is null) 
            {
                ServiceResult<Course>.Fail("Course not found", System.Net.HttpStatusCode.NotFound);
            }

            return ServiceResult<Course>.Success(course!);

        }

    }
}
