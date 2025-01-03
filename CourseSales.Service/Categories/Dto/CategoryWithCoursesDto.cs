using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseSales.Service.Courses.Create;

namespace CourseSales.Service.Categories.Dto
{
    public record CategoryWithCoursesDto(int Id, string Name, List<CourseDto> Courses);

}
