using DataAccess;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Validators;

var builder = WebApplication.CreateBuilder(args);
var connStr = builder.Configuration.GetConnectionString("LocalDb");

// Add services to the container.
// DI - Dependency Injection
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CarSalonDbContext>(opts => opts.UseSqlServer(connStr));


builder.Services.AddAutoMapper();
builder.Services.AddFluentValidators();
builder.Services.AddCustomServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
