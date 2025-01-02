using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CourseSales.Service.ExceptionHandlers
{
    public class CriticalExceptionHandler:IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is CriticalException) 
            {
                Console.WriteLine("Hata ile ilgili sms gönderildi");
            }
            //business logic
            return ValueTask.FromResult(false);
        }
    }
}
