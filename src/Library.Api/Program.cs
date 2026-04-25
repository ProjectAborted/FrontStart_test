using Library.Application.Interfaces;
using Library.Application.Services;
using Library.Domain.Interfaces;
using Library.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register Layers (Dependency Injection)
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer("..."));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddMemoryCache(); // Required for caching
builder.Services.AddControllers();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>(); // Global Error Handling
app.MapControllers();
app.Run();
