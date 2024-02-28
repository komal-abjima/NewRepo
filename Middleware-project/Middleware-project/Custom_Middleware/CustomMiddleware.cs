
namespace Middleware_project.Custom_Middleware
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My custom middleware start\n");
            await next(context);
            await context.Response.WriteAsync("Hello custom middleware end\n");
        }
    }
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomApplication(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
