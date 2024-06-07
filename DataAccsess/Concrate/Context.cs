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
       
        #region Bağlantı Cümlesi
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=VAHAPDOGAN;database=AcodeX_Database; integrated security = true; Encrypt = False;");
        }
        #endregion

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
}
