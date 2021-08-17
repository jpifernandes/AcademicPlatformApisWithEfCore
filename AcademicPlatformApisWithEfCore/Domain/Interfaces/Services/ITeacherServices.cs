using AcademicPlatformApisWithEfCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Domain.Interfaces.Services
{
    public interface ITeacherServices
    {
        Task AddOne(Teacher teacher);
        Task AddMany(IEnumerable<Teacher> teachers);
        Task<Teacher> ReadById(int id);
        Task<IEnumerable<Teacher>> ReadAll();
        Task UpdateOne(Teacher teacher);
        Task DeleteById(int id);
    }
}
