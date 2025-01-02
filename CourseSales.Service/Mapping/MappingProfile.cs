using AutoMapper;
using CourseSales.Repositories.Courses;
using CourseSales.Service.Courses.Create;

namespace CourseSales.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}
