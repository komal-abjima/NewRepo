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
    //context.Response.Headers["Mykey"] = "my Values";
    //context.Response.Headers["Server"] = "my server";

    //string path = context.Request.Path;
    //string method = context.Request.Method;

    context.Response.Headers["Content-Type"] = "text/html";

    if(context.Request.Method == "GET")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<p>{id}</p>");
        }
    }

    //await context.Response.WriteAsync($"<p>{path}</p>");
    //await context.Response.WriteAsync($"<p>{method}</p>");
});

app.Run();