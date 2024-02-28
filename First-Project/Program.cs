using Microsoft.Extensions.Primitives;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    //postman post 
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

    if (queryDict.ContainsKey("firstName")){
        string firstName = queryDict["firstName"][0];
        await context.Response.WriteAsync(firstName);
    }
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

    //context.Response.Headers["Content-Type"] = "text/html";

    //if(context.Request.Method == "GET")
    //{
    //    if (context.Request.Query.ContainsKey("id"))
    //    {
    //        string id = context.Request.Query["id"];
    //        await context.Response.WriteAsync($"<p>{id}</p>");
    //    }
    //}

    //context.Response.Headers["Content-type"] = "text/html";
    //if(context.Request.Headers.ContainsKey("User-Agent")){
    //    string UserAgent = context.Request.Headers["User-Agent"];
    //    await context.Response.WriteAsync(UserAgent);
    //}

    //context.Response.Headers["Content-type"] = "text/html";
    //if (context.Request.Headers.ContainsKey("AuthorizationKey"))
    //{
    //    string auth = context.Request.Headers["AuthorizationKey"];
    //    await context.Response.WriteAsync(auth);
    //}

    //await context.Response.WriteAsync($"<p>{path}</p>");
    //await context.Response.WriteAsync($"<p>{method}</p>");
});

app.Run();