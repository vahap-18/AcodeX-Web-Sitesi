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
public class Program
{
    public static void Main(string[] args)
    {
        // Uygulama oluþturucuyu baþlat
        var builder = WebApplication.CreateBuilder(args);

        //Dependency Injection kodlarý. IBlogDal içeirisinde tanýmlanan sýnýflar EFBlogRepository dosyasýnda somutlaþtýrýldý.
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

        // Hizmetleri yapýlandýr
        ConfigureServices(builder.Services, builder.Configuration);

        // Uygulamayý oluþtur
        var app = builder.Build();

        // Geliþtirme ortamýnda deðilse hata yöneticisini ve HSTS'yi kullan
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Durum kodu sayfalarýný kullanýcýya göster
        app.UseStatusCodePagesWithReExecute("/Error", "?code={0}");

        // HTTPS'ye yönlendir
        app.UseHttpsRedirection();

        // Statik dosyalarý sun
        app.UseStaticFiles();

        // Routing'i etkinleþtir
        app.UseRouting();

        // Kimlik doðrulama için kullanýlan yapýlandýrma
        //  app.UseAuthentication();

        // Yetkilendirme için kullanýlan yapýlandýrma
        app.UseAuthorization();

        // Oturum kullanýmý için yapýlandýrma
        app.UseSession();

        // Controller rotalarýný eþleþtir
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Admin}/{action=Dashboard}/{id?}") ; 

        // Uygulamayý çalýþtýr
        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // Controller ve Views'leri ekleyin
        services.AddControllersWithViews();


        // Oturum yapýlandýrmasý
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        // Daðýtýlmýþ bellek önbelleði ekle
        services.AddDistributedMemoryCache();

        // IHttpContextAccessor için servis ekle
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        //// MVC yapýlandýrmasý (isteðe baðlý kimlik doðrulama ve yetkilendirme)
        //services.AddMvc(config =>
        //{
        //    // Yetkilendirme gereksinimi ekleyin
        //    var policy = new AuthorizationPolicyBuilder()
        //          .RequireAuthenticatedUser()
        //          .Build();
        //    config.Filters.Add(new AuthorizeFilter(policy));
        //});

        //// Kimlik doðrulama için hizmet ekleme (isteðe baðlý)
        //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        //.AddCookie(options =>
        //{
        //    // Giriþ sayfasýnýn yolunu belirtin
        //    options.LoginPath = "/Login/Index";
        //    options.Cookie.HttpOnly = true;
        //    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        //    // Oturum süresini sýfýra ayarlayýn
        //    options.ExpireTimeSpan = TimeSpan.Zero;
        //    // Oturumun süresi, her istekte yenilensin
        //    options.SlidingExpiration = true;
        //});
    }
}
