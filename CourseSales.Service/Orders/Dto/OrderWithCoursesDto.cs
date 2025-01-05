using CourseSales.Service.Courses.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSales.Service.Orders.Dto
{
    public record OrderWithCoursesDto(int Id, string Name, List<OrderDto> Orders);

}
