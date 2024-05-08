using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

public class Program
{
    public static void Main(string[] args)
    {
        // Uygulama oluþturucuyu baþlat
        var builder = WebApplication.CreateBuilder(args);

        // Hizmetleri yapýlandýr
        ConfigureServices(builder.Services);

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
        app.UseAuthentication();

        // Yetkilendirme için kullanýlan yapýlandýrma
        app.UseAuthorization();

        // Oturum kullanýmý için yapýlandýrma
        app.UseSession();

        // Controller rotalarýný eþleþtir
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // Uygulamayý çalýþtýr
        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
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

        // MVC yapýlandýrmasý
        services.AddMvc(config =>
        {
            // Yetkilendirme gereksinimi ekleyin
            var policy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();
            config.Filters.Add(new AuthorizeFilter(policy));
        });

        // Kimlik doðrulama için hizmet ekleme
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            // Giriþ sayfasýnýn yolunu belirtin
            options.LoginPath = "/Login/Index";
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            // Oturum süresini sýfýra ayarlayýn
            options.ExpireTimeSpan = TimeSpan.Zero;
            // Oturumun süresi, her istekte yenilensin
            options.SlidingExpiration = true;
        });
    }
}
