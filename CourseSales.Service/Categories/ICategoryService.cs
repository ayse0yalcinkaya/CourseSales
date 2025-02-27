﻿using CourseSales.Service.Categories.Create;
using CourseSales.Service.Categories.Dto;
using CourseSales.Service.Categories.Update;

namespace CourseSales.Service.Categories
{
    public interface ICategoryService
    {
        Task<ServiceResult<CategoryWithCoursesDto>> GetCategoryWithCoursesAsync(int categoryId);
        Task<ServiceResult<List<CategoryWithCoursesDto>>> GetCategoryWithCoursesAsync();
        Task<ServiceResult<List<CategoryDto>>> GetAllListAsync();
        Task<ServiceResult<CategoryDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest request);
        Task<ServiceResult> DeleteAsync(int id);

    }
}
