using System.Net;
using AutoMapper;
using CourseSales.Repositories;
using CourseSales.Repositories.Categories;
using CourseSales.Service.Categories.Create;
using CourseSales.Service.Categories.Dto;
using CourseSales.Service.Categories.Update;
using Microsoft.EntityFrameworkCore;

namespace CourseSales.Service.Categories
{
    public class CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper): ICategoryService
    {
        public async Task<ServiceResult<CategoryWithCoursesDto>> GetCategoryWithCoursesAsync(int categoryId)
        {
            var category = await categoryRepository.GetCategoryWithCoursesAsync(categoryId);

            if (category is null)
            {
                return ServiceResult<CategoryWithCoursesDto>.Fail("Kategori bulunamadı",
                    HttpStatusCode.NotFound);
            }

            var categoryAsDto = mapper.Map<CategoryWithCoursesDto>(category);
            return ServiceResult<CategoryWithCoursesDto>.Success(categoryAsDto);
        }

        public async Task<ServiceResult<List<CategoryWithCoursesDto>>> GetCategoryWithCoursesAsync()
        {
            var category = await categoryRepository.GetCategoryWithCourses().ToListAsync();

            

            var categoryAsDto = mapper.Map<List<CategoryWithCoursesDto>>(category);
            return ServiceResult<List<CategoryWithCoursesDto>>.Success(categoryAsDto);
        }

        public async Task<ServiceResult<List<CategoryDto>>> GetAllListAsync()
        {
            var categories = await categoryRepository.GetAll().ToListAsync();
            var categoriesAsDto = mapper.Map<List<CategoryDto>>(categories);
            return ServiceResult<List<CategoryDto>>.Success(categoriesAsDto);
        }

        public async Task<ServiceResult<CategoryDto>> GetByIdAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);

            if (category is null)
            {
                return ServiceResult<CategoryDto>.Fail("Kategori bulunamadı", HttpStatusCode.NotFound);
            }

            var categoryAsDto = mapper.Map<CategoryDto>(category);
            return ServiceResult<CategoryDto>.Success(categoryAsDto);
        }

        public async Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request)
       {
            var anyCategory = await categoryRepository.Where(x => x.Name == request.Name).AnyAsync();
            if (anyCategory)
            {
                return ServiceResult<int>.Fail("Kategori ismi veritabanında bulunmaktadır", HttpStatusCode.NotFound);
            }


            var newCategory = mapper.Map<Category>(request);

            await categoryRepository.AddAsync(newCategory);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult<int>.SuccessAsCreated(newCategory.Id, $"api/categories/{newCategory.Id}");
       }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest request)
        {
            //var category = await categoryRepository.GetByIdAsync(id);
            //if (category == null)
            //{
            //    return ServiceResult.Fail("Güncellenecek kategori bulunamadı.", HttpStatusCode.NotFound);
            //}

            var isCategoryNameExist = await categoryRepository.Where(
                x => x.Name == request.Name && x.Id != id).AnyAsync();

            if (isCategoryNameExist) 
            {
                return ServiceResult.Fail("Kategori ismi veritabanında bulunmaktadır.", HttpStatusCode.BadRequest);

            }

            var category = mapper.Map<Category>(request);
            category.Id = id;

            categoryRepository.Update(category);
            await unitOfWork.SaveChangeAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            //if (category == null)
            //{
            //    return ServiceResult.Fail("Kategori bulunamadı.", HttpStatusCode.NotFound);
            //}
            categoryRepository.Delete(category!);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }


    
        
    }

}
