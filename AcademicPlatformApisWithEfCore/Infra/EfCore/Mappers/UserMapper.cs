using AcademicPlatformApisWithEfCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicPlatformApisWithEfCore.Infra.EfCore.Mappers
{
    public class UserMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).HasColumnType("VARCHAR(40)").IsRequired();
            builder.Property(u => u.Phone).HasColumnType("CHAR(13)");
            builder.Property(u => u.Email).HasColumnType("VARCHAR(40)");
            builder.Property(u => u.Password).HasColumnType("VARCHAR(15)");

            builder.HasMany(u => u.Entries).WithOne(e => e.User).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
