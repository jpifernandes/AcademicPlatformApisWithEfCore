using AcademicPlatformApisWithEfCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Domain.Interfaces.Services
{
    public interface ICourseServices
    {
        Task AddOne(Course course);
        Task AddMany(IEnumerable<Course> courses);
        Task<Course> ReadById(int id);
        Task<IEnumerable<Course>> ReadAll();
        Task UpdateOne(Course course);
        Task DeleteById(int id);
    }
}
