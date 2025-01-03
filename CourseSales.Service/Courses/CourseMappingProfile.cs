using System.Globalization;
using AutoMapper;
using CourseSales.Repositories.Courses;
using CourseSales.Service.Courses.Create;
using CourseSales.Service.Courses.Update;

namespace CourseSales.Service.Courses
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();

            CreateMap<CreateCourseRequest, Course>().ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src
                    => src.Name.ToLowerInvariant()));

            CreateMap<UpdateCourseRequest, Course>().ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src
                    => src.Name.ToLowerInvariant()));
        }
    }
}
