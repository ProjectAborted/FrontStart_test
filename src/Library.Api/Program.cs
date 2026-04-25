using Microsoft.EntityFrameworkCore;
using Library.Application.Interfaces;
using Library.Application.Services;
using Library.Domain.Interfaces;
using Library.Infrastructure.Data;
using Library.Infrastructure.Repositories;
using Library.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// FIX: Added 'using Microsoft.EntityFrameworkCore' — was missing, causing compile error.
// FIX: Connection string now read from appsettings.json instead of hardcoded "..."
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- Dependency Injection ---
// Repositories
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IBorrowRepository, BorrowRepository>();

// Services
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IBorrowService, BorrowService>();

// Caching — required by BookService
builder.Services.AddMemoryCache();

builder.Services.AddControllers();

// FIX: Swagger was missing — launchSettings.json opens /swagger on launch,
// which returned a 404 without this registration.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

// Global error handling — must be registered before MapControllers
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();
app.Run();