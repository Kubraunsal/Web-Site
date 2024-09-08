using System.Data.Entity;

namespace WebSitesi.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AnaSayfa> AnaSayfas { get; set; }
        public DbSet<İconlar> iconlars { get; set; }
    } 
}