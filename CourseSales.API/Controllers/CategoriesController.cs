using CourseSales.Service.Categories;
using CourseSales.Service.Categories.Create;
using CourseSales.Service.Categories.Update;
using Microsoft.AspNetCore.Mvc;

namespace CourseSales.API.Controllers
{
    public class CategoriesController(ICategoryService categoryService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories() => CreateActionResult(await categoryService.GetAllListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id) => CreateActionResult(await categoryService.GetByIdAsync(id));

        [HttpGet("courses")]
        public async Task<IActionResult> GetCategoryWithCourses() => CreateActionResult(await categoryService
            .GetCategoryWithCoursesAsync());

        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetCategoryWithCourses(int id) => CreateActionResult(await categoryService
            .GetCategoryWithCoursesAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request) => CreateActionResult(await 
            categoryService.CreateAsync(request));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryRequest request) => CreateActionResult(await
            categoryService.UpdateAsync(id, request));

        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteCategory(int id) => CreateActionResult(await categoryService .DeleteAsync(id));


    }
}
