using System.Net;
using CourseSales.Service.Courses;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await courseService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseRequest request) =>
            CreateActionResult(await courseService.CreateAsync(request));

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateCourseRequest request) =>
            CreateActionResult(await courseService.UpdateAsync(id, request));

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) =>
            CreateActionResult(await courseService.DeleteAsync(id));
    }
}
