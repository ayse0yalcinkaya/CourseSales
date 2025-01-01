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
        public Task<List<Course>> GetTopPriceCourseAsync(int count)
        {
            return courseRepository.GetTopPriceCourseAsync(count);
        }
    }
}
