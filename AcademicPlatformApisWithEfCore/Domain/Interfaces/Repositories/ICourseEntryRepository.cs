using AcademicPlatformApisWithEfCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Domain.Interfaces.Repositories
{
    public interface ICourseEntryRepository
    {
        Task AddOne(CourseEntry entry);
        Task AddMany(IEnumerable<CourseEntry> entries);
        Task<IEnumerable<CourseEntry>> ReadByCourse(int courseId);
        Task<IEnumerable<CourseEntry>> ReadByUser(int userId);
        Task DeleteById(int id);
    }
}
