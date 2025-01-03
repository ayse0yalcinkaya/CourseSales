using AutoMapper;
using CourseSales.Repositories.Categories;
using CourseSales.Service.Categories.Create;
using CourseSales.Service.Categories.Dto;
using CourseSales.Service.Categories.Update;

namespace CourseSales.Service.Categories
{
    public class CategoryProfileMapping: Profile
    {
        public CategoryProfileMapping()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();

            CreateMap<Category, CategoryWithCoursesDto>().ReverseMap();

            CreateMap<CreateCategoryRequest, Category>().ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src
                    => src.Name.ToLowerInvariant()));

            CreateMap<UpdateCategoryRequest, Category>().ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src
                    => src.Name.ToLowerInvariant()));
        }
    }
}
