using ABDM.Helpers;
using Serilog;

namespace ABDM.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            Log.Information(ex,"Global Exception Occurred");
            ApiResponse<object> response = new ApiResponse<object>(false, 500, ex.Message, null);
            await context.Response.WriteAsJsonAsync(response);
        }

    }
}
