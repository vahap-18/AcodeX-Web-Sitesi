using BussinesLayer.Abstarct;
using BussinesLayer.Concrate;
using DataAccsess.Concrate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DataAccsess.Abstract;
using EntityLayer.Concrate;
using System.Resources;
using DataAccsess.EntityFramework;
using Azure.ResourceManager.Storage;
using AcodeX_Web_Sitesi.Models;
using AcodeX_Web_Sitesi.Controllers;

public class Program
{
    public static void Main(string[] args)
    {
        // Uygulama oluþturucuyu baþlat
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTransient<IEmailSender, EMailSenderManager>();

        builder.Services.AddScoped<IBlogDal, EFBlogRepository>();
        builder.Services.AddScoped<BlogManager, BlogManager>();

        builder.Services.AddScoped<IAboutDal, EFAboutRepository>();
        builder.Services.AddScoped<AboutManager, AboutManager>();

        builder.Services.AddScoped<ICategoryDal, EFCategoryRepository>();
        builder.Services.AddScoped<CategoryManager, CategoryManager>();

        builder.Services.AddScoped<IEducationDal, EFEducationRespository>();
        builder.Services.AddScoped<EducationManager, EducationManager>();

        builder.Services.AddScoped<IWriterDal, EFWriterRepository>();
        builder.Services.AddScoped<WriterManager, WriterManager>();


        ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseStatusCodePagesWithReExecute("/Error", "?code={0}");
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        // Kimlik doðrulama için kullanýlan yapýlandýrma
        app.UseAuthentication();

        // app.UseAuthorization();
        app.UseSession();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Admin}/{action=Dashboard}/{id?}");
        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Context>();
        services.AddIdentity<User, UserRole>(x =>
        {
            x.Password.RequireUppercase = true;
            x.Password.RequireLowercase = true;
            x.Password.RequireDigit = true;
            x.Password.RequiredLength = 6;

            x.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityErrorDescriber>();

        services.AddControllersWithViews();
        services.AddHttpClient();

        //Oturum yapýlandýrmasý
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        services.AddDistributedMemoryCache();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddMvc(config =>
        {
            var policy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();
            config.Filters.Add(new AuthorizeFilter(policy));

        });

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.ExpireTimeSpan = TimeSpan.Zero;
            options.SlidingExpiration = true;
        });
    }
}
