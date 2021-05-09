using EntityFramework5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework5.Data.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.Property(b => b.Title)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            builder.HasData(
                new Book { Id = 1, AuthorId = 1, Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software", ReleaseYear = 2003 },
                new Book { Id = 2, AuthorId = 2, Title = "Agile Principles, Patterns, and Practices in C#", ReleaseYear = 2006 },
                new Book { Id = 3, AuthorId = 2, Title = "Clean Code: A Handbook of Agile Software Craftsmanship", ReleaseYear = 2008 },
                new Book { Id = 4, AuthorId = 3, Title = "Implementing Domain-Driven Design", ReleaseYear = 2013 },
                new Book { Id = 5, AuthorId = 4, Title = "Patterns, Principles, and Practices of Domain-Driven Design", ReleaseYear = 2015 },
                new Book { Id = 6, AuthorId = 5, Title = "Refactoring: Improving the Design of Existing Code", ReleaseYear = 2012 }
            );
        }
    }
}
