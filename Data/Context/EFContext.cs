using EntityFramework5.Data.Mappings;
using EntityFramework5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using static System.Console;

namespace EntityFramework5.Data.Context
{
    public class EFContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public EFContext(IConfiguration configuration)
        {
            _configuration = configuration;

            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"])
                .LogTo(WriteLine, new[] { RelationalEventId.CommandExecuted })
                .EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMap());
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new GroupMap());
        }
    }
}
