using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniLibrary.Data;
using UniLibrary.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcUserContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcUserContext") ?? throw new InvalidOperationException("Connection string 'MvcUserContext' not found.")));
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MvcBookContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("MvcBookContext")));
}
else
{
    builder.Services.AddDbContext<MvcBookContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMvcBookContext")));
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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
