using Microsoft.Extensions.DependencyInjection;
using UniLibrary.Models;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql;
using UniLibrary.Data;
using Microsoft.EntityFrameworkCore;
using UniLibrary.Interfaces;
using UniLibrary.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcComputerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcComputerContext") ?? throw new InvalidOperationException("Connection string 'MvcComputerContext' not found.")));
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
});

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Default"))));
// Add services to the container.
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookCopyLoanService, BookCopyLoanService>();
builder.Services.AddScoped<IBookCopyService, BookCopyService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
