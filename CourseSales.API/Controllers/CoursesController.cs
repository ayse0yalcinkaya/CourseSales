using CourseSales.Service.Courses;
using CourseSales.Service.Courses.Create;
using CourseSales.Service.Courses.Update;
using Microsoft.AspNetCore.Mvc;

namespace CourseSales.API.Controllers
{

    public class CoursesController(ICourseService courseService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var serviceResult = await courseService.GetAllListAsync();

            return CreateActionResult(serviceResult);
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedAll(int pageNumber, int pageSize)
        {
            var serviceResult = await courseService.GetPagedAllListAsync(pageNumber, pageSize);

            return CreateActionResult(serviceResult);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await courseService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseRequest request)
        {
            return CreateActionResult(await courseService.CreateAsync(request));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateCourseRequest request) =>
            CreateActionResult(await courseService.UpdateAsync(id, request));

        [HttpPatch("stock")]
        public async Task<IActionResult> UpdateStock(UpdateCourseStockRequest request) =>
            CreateActionResult(await courseService.UpdateStockAsync(request));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) =>
            CreateActionResult(await courseService.DeleteAsync(id));
    }
}
