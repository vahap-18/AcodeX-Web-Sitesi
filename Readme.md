# AcodeX Web Sitesi Rapor
**Proje Tanımı**

AcodeX, modern web geliştirme standartlarına uygun olarak tasarlanmış, MVC mimarisine dayalı bir web projesidir. Temel olarak, kullanıcıların ihtiyaçlarına yönelik farklı rollerde ve yetkilerde oluşturulan bu platform, blog ve eğitim içeriklerini barındırmakta ve kullanıcılar arasında etkileşimi sağlamaktadır.

   - Proje web tabanlı olup Back-end kısmı C#, JavaScript; Front-end kısmı ise HTML, CSS ve JavaScript ile kodlanmıştır.
   - Hedef çerçeve .NET 8.0'dır.

**Yazılımsal Özellikler** 

AcodeX web sitesi için kullanılacak teknolojiler ve yöntemler: 

    - **Sunucu Tarafı Programlama Dili ve Çatısı:** Sunucu tarafı işlemleri gerçekleştirmek için ASP.NET (C#) kullanıldı.
    
    - **Veritabanı:** Microsoft SQL Server yönetim biçimi ile SQL programlama dili ile veriler kayıt altına alındı. 
    
    - **Web Framework/CMS (Content Management System):** Web sitesi geliştirme sürecini hızlandırmak için ASP.NET MVC veya ASP.NET Core (C#) gibi frameworklar tercih edildi.
    
    - **Frontend Teknolojileri:** Web sitesinin arayüzünü oluşturmak için HTML, CSS ve JavaScript kullanılacak. Arayüzü geliştirmek için popüler kütüphaneler ve araçlar arasında Bootstrap ve JQuery kullanıldı.
    
    - **Geliştirme Ortamı:** Proje gelişim aşamasında Visual Studio ve SQL Server Management Studio kullanıldı. ılacak. 
## Veri Tabanı
**Projede Code-First Yaklaşımının Kullanılması**

AcodeX projesinde, veritabanı tasarımını ve yönetimini kolaylaştırmak için Code-First yaklaşımını kullandım. Bu yaklaşım, veritabanı şemasını uygulama kodu üzerinden tanımlamama ve yönetmeme olanak tanır. İşte bu yaklaşımın detayları:

1. **Entity Sınıflarının Oluşturulması:**

   Code-First yaklaşımında, önce veritabanı tablolarını temsil eden entity sınıflarını oluşturdum. Örneğin, blog ve kullanıcılar için aşağıdaki gibi sınıflar tanımladım:

    public class Blog
 {
     [Key]
     public int BlogId { get; set; }
     public string Title { get; set; } = "";
     public string Description { get; set; } = "";
     public string Content { get; set; } = "";
     public DateTime CreateDate { get; set; }
     public string? Image { get; set; } = "";
     public bool Status { get; set; } = true;
     public int CategoryId { get; set; }
     public Category? Category { get; set; } 
     public int WriterId { get; set; }
     public Writer? Writer { get; set; }
     public List<Comment>? Comments { get; set; }
 } 

 
    public class User : IdentityUser<int>
 {
    public required string NameSurname { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string? FieldOfInterest { get; set; }
    public string? About { get; set; }
    public string? Country { get; set; }
    public string? Adress { get; set; }
    public string? GitHub { get; set; }
    public string? KnowTeknologies { get; set; }
    public string? ProgrammingLanguages { get; set; }
    public bool Status { get; set; } = true;
    public List<Blog>? Blogs { get; set; }
    public DateTime CreateDate { get; set; }
 }
2. **DbContext Sınıfının Oluşturulması:**

   Bu entity sınıflarını kullanarak bir DbContext sınıfı tanımladım. DbContext, veritabanı işlemlerini yönetir ve entity sınıflarını veritabanı tablolarına dönüştürür.

    public class Context:IdentityDbContext<User, UserRole, int>
 {
     public DbSet<About> Abouts { get; set; }
     public DbSet<Blog> Blogs { get; set; }
     public DbSet<Category> Categories { get; set; }
     public DbSet<Comment> Comments { get; set; }
     public DbSet<Contact> Contacts { get; set; }
     public DbSet<Writer> Writers { get; set; }
     public DbSet<NewsLetter> NewsLetters { get; set; }
     public DbSet<BlogRayting> BlogRaytings{ get; set; }
     public DbSet<Notification> Notifications{ get; set; }
     public DbSet<Education> Educations { get; set; }
     public DbSet<Admin> Admins { get; set; }
 }
3. **Migration Kullanımı:**

   Entity Framework'ün Code-First yaklaşımı ile birlikte gelen Migration özelliğini kullanarak, veritabanı şemasını güncelledim. Migration, veritabanı şemasında yapılan değişiklikleri izler ve bu değişiklikleri veritabanına uygular.
  PM > Add-Migration InitialCreate
  PM > Update-Database
   Bu komutlarla, entity sınıflarıma dayalı olarak veritabanı tablolarını oluşturmak için ilk migration'ı ekledim ve veritabanını güncelledim.

4. **Veritabanı Güncellemeleri:**

   Proje ilerledikçe, entity sınıflarında yapılan değişiklikleri migrationlar aracılığıyla veritabanına uyguladım. Örneğin, bir blog sınıfına yeni bir özellik eklemek istediğimde, entity sınıfını güncelledim ve yeni bir migration oluşturarak bu değişikliği veritabanına yansıttım.

   public class Blog
   {
       public int BlogId { get; set; }
       public string Title { get; set; }
       public string Content { get; set; }
       public DateTime CreatedDate { get; set; }
       public int AuthorId { get; set; }
       public virtual Writer Author { get; set; }
   }
 
    
  PM > Add-Migration FirstMigration
  PM > Update-Database
**SSMS Diyagram**

Diyagramda yer alan bazı tablolar Entity ile hazırlanıp ve migration işlemi sonucunda veri tabanında oluşmuş tablolardır. Bir kısmı ise Identity kullanımı sonucunda hazır gelen tablolardır.

![Diagram.png](attachment:Diagram.png)
# Proje Katmanları
