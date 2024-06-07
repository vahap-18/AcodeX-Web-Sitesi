using Microsoft.EntityFrameworkCore;

namespace APILayer.DataAccess
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=VAHAPDOGAN;database=AcodeX_API_Database; integrated security = true; Encrypt = False;");
        }

        public DbSet<User> Users { get; set; }
    }
}
