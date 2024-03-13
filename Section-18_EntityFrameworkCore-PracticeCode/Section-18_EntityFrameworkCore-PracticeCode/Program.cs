using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Section_18_EntityFrameworkCore_PracticeCode.Data;
using Section_18_EntityFrameworkCore_PracticeCode.Models;
using Section_18_EntityFrameworkCore_PracticeCode.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<IBookRepository,  BookRepository>();
//builder.Services.AddScoped<IBookRepository, BookRepository>();
//builder.Services.AddSingleton<IBookRepository, BookRepository>();
//builder.Services.TryAddSingleton<IBookRepository, BookRepository>();
//builder.Services.TryAddScoped<IBookRepository, BookRepository>();
//builder.Services.TryAddTransient<IBookRepository, BookRepository>();



builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
