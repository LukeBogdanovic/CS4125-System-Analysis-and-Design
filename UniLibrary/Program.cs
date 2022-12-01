using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using UniLibrary.Models;
using UniLibrary.Data;
using Microsoft.EntityFrameworkCore;
using UniLibrary.Interfaces;
using UniLibrary.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/login";
    options.Cookie.Name = "LoginCookie";
});
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("Default"), MariaDbServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Default"))));
// Add services to the container.
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookCopyLoanService, BookCopyLoanService>();
builder.Services.AddScoped<IBookCopyService, BookCopyService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<IReserveService, ReservationService>();
builder.Services.AddScoped<IRoomReservationService, RoomReservationService>();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
    options.AddPolicy("PostGraduate", policy => policy.RequireClaim("PostGraduate"));
    options.AddPolicy("UnderGraduate", policy => policy.RequireClaim("UnderGraduate"));
    options.AddPolicy("AllRegisteredUsers", policy => policy.RequireClaim("AllRegisteredUsers"));
});
builder.Services.AddRazorPages();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
This line of writing should have been commented out, however whomst ever wrote it "forgot" to comment it out and now dotnet build fails.
Its sole purpose is to demonstrate how our github actions prevents code which doesnt build from being merged into main.
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();