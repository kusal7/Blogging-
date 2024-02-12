using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using AutoMapper;
using DBManager;
using KushalBlogWebApp.Data.IServices;
using KushalBlogWebApp.Data.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
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


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o =>
    {

        //o.ExpireTimeSpan = TimeSpan.FromDays(5);
        o.ExpireTimeSpan = TimeSpan.FromMinutes(15);
        o.Events = new CookieAuthenticationEvents
        {
            OnValidatePrincipal = context =>
            {
                if (context.Request.Query.TryGetValue("returnUrl", out var returnUrl))
                {
                    // Store the returnUrl in the authentication ticket
                    context.Properties.RedirectUri = returnUrl;
                }
                return Task.CompletedTask;
            },
            //OnRedirectToLogin = context =>
            //{
            //    if (!context.Request.Path.StartsWithSegments("/Account/Login"))
            //    {
            //        // Store the original request path as the custom return URL
            //        context.Response.Redirect("/Home/AdminLoginPage?returnUrl=" + Uri.EscapeDataString(context.Request.Path));
            //    }
            //    return Task.CompletedTask;
            //}

            OnRedirectToLogin = context =>
            {
                // Check if the request path does not start with the Admin login path
                if (!context.Request.Path.StartsWithSegments("/Home/AdminLoginPage"))
                {
                    // Store the original request path as the custom return URL
                    context.Response.Redirect("/Home/AdminLoginPage?returnUrl=" + Uri.EscapeDataString(context.Request.Path));
                }
                return Task.CompletedTask;
            }
        };
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