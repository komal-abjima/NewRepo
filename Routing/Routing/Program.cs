var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//enabled routing
app.UseRouting();

//creating end points
app.UseEndpoints(endpoints =>
{
    //endpoints.Map("map1", async (context) =>
    //{
    //    await context.Response.WriteAsync("In map 1");
    //});

    //endpoints.Map("map2", async (context) =>
    //{
    //    await context.Response.WriteAsync("In map 2");
    //});

    endpoints.MapGet("map1", async (context) =>
    {
        await context.Response.WriteAsync("In map 1");

    });

    endpoints.MapPost("map2", async (context) =>
    {
        await context.Response.WriteAsync("In map 1");

    });

});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
