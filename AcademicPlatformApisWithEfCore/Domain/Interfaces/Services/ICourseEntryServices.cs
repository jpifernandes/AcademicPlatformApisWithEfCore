using AcademicPlatformApisWithEfCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Domain.Interfaces.Services
{
    public interface ICourseEntryServices
    {
        Task AddOne(CourseEntry entry);
        Task AddMany(IEnumerable<CourseEntry> entries);
        Task<IEnumerable<CourseEntry>> ReadByCourse(int courseId);
        Task<IEnumerable<CourseEntry>> ReadByUser(int userId);
        Task DeleteById(int id);
    }
}
