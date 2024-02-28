using Middleware_project.Custom_Middleware;


//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<CustomMiddleware>();
//var app = builder.Build();

////app.MapGet("/", () => "Hello World!");

////without middleware it only runs first run

////middleware 1
////app.Use(async (HttpContext context, RequestDelegate next) =>
////{
////    await context.Response.WriteAsync("Hello from middleware 1\n");
////    await next(context);
////});


////useWhen 
//app.UseWhen(
//    context => context.Request.Query.ContainsKey("username"),
//    app =>
//    {
//        app.Use(async (context, next) =>
//        {
//            await context.Response.WriteAsync("Hello from middleware branch");
//            await next();
//        });
//    });

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello from middleware main chain");
//});


////middleware 2
////app.Use(async (context, next) =>
////{
////    await context.Response.WriteAsync("Hello again");
////    await next(context);
////});

////app.UseMiddleware<CustomMiddleware>();
////app.UseCustomApplication();
////app.UseHelloCustomModel();


////middleware 3
////app.Run(async (HttpContext context) =>
////{
////    await context.Response.WriteAsync("Hello from middleware third\n");
////});

//app.Run();
