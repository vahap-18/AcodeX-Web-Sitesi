using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

public class Program
{
    public static void Main(string[] args)
    {
        // Uygulama olu�turucuyu ba�lat
        var builder = WebApplication.CreateBuilder(args);

        // Hizmetleri yap�land�r
        ConfigureServices(builder.Services);

        // Uygulamay� olu�tur
        var app = builder.Build();

        // Geli�tirme ortam�nda de�ilse hata y�neticisini ve HSTS'yi kullan
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Durum kodu sayfalar�n� kullan�c�ya g�ster
        app.UseStatusCodePagesWithReExecute("/Error", "?code={0}");

        // HTTPS'ye y�nlendir
        app.UseHttpsRedirection();

        // Statik dosyalar� sun
        app.UseStaticFiles();

        // Routing'i etkinle�tir
        app.UseRouting();

        // Kimlik do�rulama i�in kullan�lan yap�land�rma
        app.UseAuthentication();

        // Yetkilendirme i�in kullan�lan yap�land�rma
        app.UseAuthorization();

        // Oturum kullan�m� i�in yap�land�rma
        app.UseSession();

        // Controller rotalar�n� e�le�tir
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // Uygulamay� �al��t�r
        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Controller ve Views'leri ekleyin
        services.AddControllersWithViews();

        // Oturum yap�land�rmas�
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        // Da��t�lm�� bellek �nbelle�i ekle
        services.AddDistributedMemoryCache();

        // IHttpContextAccessor i�in servis ekle
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // MVC yap�land�rmas�
        services.AddMvc(config =>
        {
            // Yetkilendirme gereksinimi ekleyin
            var policy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();
            config.Filters.Add(new AuthorizeFilter(policy));
        });

        // Kimlik do�rulama i�in hizmet ekleme
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            // Giri� sayfas�n�n yolunu belirtin
            options.LoginPath = "/Login/Index";
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            // Oturum s�resini s�f�ra ayarlay�n
            options.ExpireTimeSpan = TimeSpan.Zero;
            // Oturumun s�resi, her istekte yenilensin
            options.SlidingExpiration = true;
        });
    }
}
