var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    //if(1 == 1)
    //{
    //    context.Response.StatusCode = 200;
    //}
    //else
    //{
    //    context.Response.StatusCode = 400;

    //}
    context.Response.Headers["Mykey"] = "my Values";
    context.Response.Headers["Server"] = "my server";
    context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h1>Hello</h1>");
    await context.Response.WriteAsync("<h2>Dot Net</h2>");
});

app.Run();