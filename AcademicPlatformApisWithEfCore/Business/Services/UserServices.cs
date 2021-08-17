using AcademicPlatformApisWithEfCore.Domain.Entities;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Repositories;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Business.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;

        public UserServices(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task AddOne(User user) => _repository.AddOne(user);

        public Task AddMany(IEnumerable<User> users) => _repository.AddMany(users);

        public Task<User> ReadById(int id) => _repository.ReadById(id);

        public Task<IEnumerable<User>> ReadAll() => _repository.ReadAll();

        public Task UpdateOne(User user) => _repository.UpdateOne(user);

        public Task DeleteById(int id) => _repository.DeleteById(id);
    }
}
