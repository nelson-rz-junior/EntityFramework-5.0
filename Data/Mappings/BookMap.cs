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
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            builder.HasData(
                new Book { Id = 1, AuthorId = 1, Title = "Head First C#: A Learner's Guide to Real-World Programming with C# and .NET Core", ReleaseYear = 2021 },
                new Book { Id = 2, AuthorId = 2, Title = "ASP.NET Core 3 and Angular 9: Full stack web development with .NET Core 3.1 and Angular 9, 3rd Edition", ReleaseYear = 2020 },
                new Book { Id = 3, AuthorId = 3, Title = "Hands-On Network Programming with C# and .NET Core: Build robust network applications with C# and .NET Core", ReleaseYear = 2019 },
                new Book { Id = 4, AuthorId = 4, Title = "Pro C# 9 with .NET 5: Foundational Principles and Practices in Programming", ReleaseYear = 2021 },
                new Book { Id = 5, AuthorId = 5, Title = "Professional C# 7 and .NET Core 2.0", ReleaseYear = 2018 }
            );
        }
    }
}
