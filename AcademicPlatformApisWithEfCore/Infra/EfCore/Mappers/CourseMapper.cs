using AcademicPlatformApisWithEfCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicPlatformApisWithEfCore.Infra.EfCore.Mappers
{
    public class CourseMapper : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasColumnType("VARCHAR(40)").IsRequired();
            builder.Property(c => c.Description).HasColumnType("VARCHAR(200)");
            builder.Property(c => c.TeacherId).IsRequired(false).HasDefaultValue(0);

            builder.HasOne(c => c.Teacher).WithMany(t => t.Courses).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Entries).WithOne(e => e.Course).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
