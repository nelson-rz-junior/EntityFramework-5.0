using EntityFramework5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework5.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(u => u.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasMany(g => g.Groups)
                .WithMany(u => u.Users)
                .UsingEntity<Membership>(
                    j => j.HasOne(m => m.Group).WithMany(g => g.Memberships),
                    j => j.HasOne(m => m.User).WithMany(u => u.Memberships));
        }
    }
}
