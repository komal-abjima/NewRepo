namespace Middleware_project.Custom_Middleware
{
    public class HelloCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public HelloCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            if (context.Request.Query.ContainsKey("firstname") && context.Request.Query.
                ContainsKey("lastname"))
            {
                string fullname = context.Request.Query["firstname"] + " " + context.Request.Query["lastname"];
                await context.Response.WriteAsync(fullname);
            }

            await _next(context);
            //after logic

        }
    }
    public static class HelloCustomModelExtensions
    {
        public static IApplicationBuilder UseHelloCustomModel(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HelloCustomMiddleware>();
        }
    }
}
