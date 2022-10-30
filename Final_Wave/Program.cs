using Final_Wave.AutoMapper;
using Final_Wave.Core.PublicFile.Services;
using Final_Wave.Core.PublicFile;
using Final_Wave.DataLayer.Contexxt;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Final_Wave.DataLayer.Repository.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using static System.Net.Mime.MediaTypeNames;
using Polly;
using Final_Wave.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//signalr
builder.Services.AddSignalR();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



//Identity Methods
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();



#region RegisterInterfaces
////Recognizing the interface
builder.Services.AddScoped<IUploadFiels, UploadFiel>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepasitory, ProductService>();
builder.Services.AddAutoMapper(typeof(AutoMapping).Assembly);
#endregion

//end cors
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});//on signalR

// for taostr
builder.Services.AddNotyf(config =>
{ config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });
 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//error 404
app.Use(async (Context , next) =>
{
    await next();
    if(Context.Response.StatusCode == 404)
    {
        Context.Request.Path = "/Home/Err404";
        await next();
    }
});


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseNotyf();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/ChatHub");


app.MapAreaControllerRoute(
    "AdminArea",
    "AdminArea",
    "AdminArea/{controller=UserManager}/{action=Index}/{id?}");
//userarearout
app.MapAreaControllerRoute(
 "UserArea",
 "UserArea",
 "UserArea/{controller=Chat}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MainSite}/{action=Index}/{id?}");
app.Run();
