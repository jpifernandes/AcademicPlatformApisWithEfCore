using AcademicPlatformApisWithEfCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Domain.Interfaces.Services
{
    public interface IUserServices
    {
        Task AddOne(User user);
        Task AddMany(IEnumerable<User> users);
        Task<User> ReadById(int id);
        Task<IEnumerable<User>> ReadAll();
        Task UpdateOne(User user);
        Task DeleteById(int id);
    }
}
