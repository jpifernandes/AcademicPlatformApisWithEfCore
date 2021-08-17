using AcademicPlatformApisWithEfCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademicPlatformApisWithEfCore.Infra.EfCore.Mappers
{
    public class TeacherMapper : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(t => t.Cpf).HasColumnType("CHAR(11)");
            builder.Property(t => t.CtpsNumber).HasColumnType("CHAR(10)");

            builder.HasMany(t => t.Courses).WithOne(c => c.Teacher).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
