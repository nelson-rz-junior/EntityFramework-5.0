using EntityFramework5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework5.Data.Mappings
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");

            builder.Property(a => a.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasData(
                new Author { Id = 1, Name = "Eric Evans" },
                new Author { Id = 2, Name = "Robert C. Martin" },
                new Author { Id = 3, Name = "Vaughn Vernon" },
                new Author { Id = 4, Name = "Scott Millet" },
                new Author { Id = 5, Name = "Martin Fowler" }
            );
        }
    }
}
