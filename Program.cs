using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCApp.Data;
using MVCApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVCAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCAppContext") ?? throw new InvalidOperationException("Connection string 'MVCAppContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope=app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
