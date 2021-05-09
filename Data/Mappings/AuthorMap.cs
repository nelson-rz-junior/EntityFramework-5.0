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
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.HasData(
                new Author { Id = 1, Name = "Andrew Stellman and Jennifer Greene" },
                new Author { Id = 2, Name = "Valerio De Sanctis" },
                new Author { Id = 3, Name = "Sean Burns" },
                new Author { Id = 4, Name = "Andrew Troelsen and Phillip Japikse" },
                new Author { Id = 5, Name = "Christian Nagel" }
            );
        }
    }
}
