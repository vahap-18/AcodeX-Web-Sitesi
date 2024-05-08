using EntityLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrate
{
    public class Context:DbContext
    {
        //Bağlantı cümlesini
        #region Bağlantı Cümlesi
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Bağlantı cümlesini yazarken Encrypt özelliği False olduğu zaman SSL sertifika hatası almayacaktır.
            optionsBuilder.UseSqlServer("server=VAHAPDOGAN;database=AcodeX_Database; integrated security = true; Encrypt = False;");
        }
        #endregion

        // Veri tabanına karşılık gelen tabloları sınıf olarak tanımlanır. Tanımlanan sınıflardan nesneler oluşturulur.
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }

    }
}
