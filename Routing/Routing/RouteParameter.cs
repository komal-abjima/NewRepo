using Routing.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
});
var app = builder.Build();

app.UseStaticFiles();

//enable routing
app.UseRouting();

//creating endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{filename}.{extension}", async context => {

        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In files -{fileName} - {extension}");

    });


    //DFAULT PARAMETERS
    //endpoints.Map("employee/profile/{EmployeeName=harsha}", async context =>
    //{
    //    string? EmpName = Convert.ToString(context.Request.RouteValues["EmployeeName"]);
    //    await context.Response.WriteAsync($"The employee is: {EmpName}");
    //});

    //Default length
    endpoints.Map("employee/profile/{EmployeeName:length(4,7):alpha=harsha}", async context =>
    {
        string? EmpName = Convert.ToString(context.Request.RouteValues["EmployeeName"]);
        await context.Response.WriteAsync($"The employee is: {EmpName}");
    });

    //products/details/1
    //endpoints.Map("products/details/{id=1}", async context =>
    //{
    //    int id = Convert.ToInt32(context.Request.RouteValues["id"]);
    //    await context.Response.WriteAsync($"The id is {id}");
    //});


    //optional Parameters
    endpoints.Map("products/details/{id:int:range(1,1000)?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"The id is {id}");

        }
        else
        {
            await context.Response.WriteAsync("Id is not entered");
        }
    });


    //endpoints.Map("employee/profile/{EmployeeName?}", async context =>
    //{
    //    if (context.Request.RouteValues.ContainsKey("EmployeeName"))
    //    {
    //    string? EmpName = Convert.ToString(context.Request.RouteValues["EmployeeName"]);
    //    await context.Response.WriteAsync($"The employee is: {EmpName}");

    //    }
    //    else
    //    {
    //        await context.Response.WriteAsync("Name is not defined");
    //    }
    //});


    //Route Constraints
    endpoints.Map("daily-digest-report/{reportDate:datetime}", async context =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportDate"]);
        await context.Response.WriteAsync($"In daily digest report: {reportDate.ToShortDateString()}");
    });

    //eg: cities/cityid
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
        await context.Response.WriteAsync($"City information: {cityId}");
    });

    //sales-report/2030/apr
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        if(month == "apr" || month == "jun" || month == "jan")
        {
        await context.Response.WriteAsync($"sales report - {year} and month is {month}");

        }
        else
        {
            await context.Response.WriteAsync("the month is invalid");
        }

    });

    //endpoint selection order
    app.Map("sales-report/2024/jan", async context =>
    {
        await context.Response.WriteAsync("Sales report it is preferred short spelling as jan");
    });

});


app.Run(async context => {
    await context.Response.WriteAsync($"No route matched, This is a wrong path - {context.Request.Path}");
});
app.Run();  