using Microsoft.EntityFrameworkCore;
using WPFAspire.Database.Entities;


namespace WPFAspire.Database
{
    public class AspireDbContext : DbContext
    {
        public AspireDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>()
                .HasKey(x => x.Id);
        }
        
        public DbSet<Contact> Contacts { get; set; }
    }
}
