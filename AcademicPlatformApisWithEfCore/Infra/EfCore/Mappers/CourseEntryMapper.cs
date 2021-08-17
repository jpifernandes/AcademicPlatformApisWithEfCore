using AcademicPlatformApisWithEfCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicPlatformApisWithEfCore.Infra.EfCore.Mappers
{
    public class CourseEntryMapper : IEntityTypeConfiguration<CourseEntry>
    {
        public void Configure(EntityTypeBuilder<CourseEntry> builder)
        {
            builder.ToTable("CourseEntries");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Course).WithMany(c => c.Entries).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.User).WithMany(u => u.Entries).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
