using ITI_System.Filters;
using ITI_System.Models;
using ITI_System.Repositry;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddViewOptions(options =>
{
    options.HtmlHelperOptions.ClientValidationEnabled = true;
});
builder.Services.AddScoped<IDeptReprositry,DeptRepositry>();
builder.Services.AddScoped<ICrsReprositry,CrsRepositry>();
builder.Services.AddScoped<IinstructorRepositry, InstructorRepositry>();
builder.Services.AddScoped<IcrsResultRepositry, crsresultRepositry>();
builder.Services.AddScoped<ItraineeRepositry, TraineeRepositry>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(Options =>
{
    Options.Password.RequiredLength = 4;
    Options.Password.RequireNonAlphanumeric = false;
    }
)
    .AddEntityFrameworkStores<ModelContext>();
builder.Services.AddDbContext<ModelContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
