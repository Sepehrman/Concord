using Microsoft.EntityFrameworkCore;
using Concord.Models;

namespace Concord.Models {
    public class DatabaseContext : DbContext {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Channel>()
                .Property(e => e.Created)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<Message>()
                .Property(e => e.Created)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<Message>()
                .Property(e => e.UserName)
                .HasDefaultValue("Sepehr");
        }
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Channel> Channels => Set<Channel>();

    }


}