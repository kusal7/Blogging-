using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using AutoMapper;
using DBManager;
using KushalBlogWebApp.Data.IServices;
using KushalBlogWebApp.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using TeamEleven.Data.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IAdminBlogService, AdminBlogService>();


var serviceProvider = Serviceprovider(builder.Services);
IDatabaseFactory dbFactory = DatabaseFactories.SetFactory(Dialect.SQLServer, serviceProvider);
builder.Services.AddSingleton(dbFactory);

//Add AutoMapper Services
var mapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile<MappingProfiles>();
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5; config.IsDismissable = true; config.Position = NotyfPosition.TopRight;
});



var app = builder.Build();
app.UseNotyf();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
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

app.MapRazorPages();

app.Run();


ServiceProvider Serviceprovider(IServiceCollection services)
{
    return builder.Services.BuildServiceProvider();
}