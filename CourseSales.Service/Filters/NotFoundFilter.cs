using CourseSales.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CourseSales.Service.Filters
{
    public class NotFoundFilter<T, TId>(IGenericRepository<T, TId> genericRepository): Attribute, IAsyncActionFilter where T : class
    where TId : struct
    {
        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            var idKey = context.ActionArguments.Keys.First();
            if (idValue == null && idKey != "id")
            {
                await next();
                return;
            }

            if (!(idValue is TId id))
            {
                await next();
                return;
            }

            var anyEntity = await genericRepository.AnyAsync(id);

            if (!anyEntity)
            {

                var entityName = typeof(T).Name;

                var actionName = context.ActionDescriptor.RouteValues["action"];

                var result = ServiceResult.Fail($"Data bulunamadı ({entityName})({actionName})");
                context.Result = new NotFoundObjectResult(result);
                return;
            }

            await next();
        }
    }
}
