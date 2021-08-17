using AcademicPlatformApisWithEfCore.Domain.Entities;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Repositories;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Business.Services
{
    public class TeacherServices : ITeacherServices
    {
        private readonly ITeacherRepository _repository;

        public TeacherServices(ITeacherRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task AddOne(Teacher teacher) => _repository.AddOne(teacher);

        public Task AddMany(IEnumerable<Teacher> teachers) => _repository.AddMany(teachers);

        public Task<Teacher> ReadById(int id) => _repository.ReadById(id);

        public Task<IEnumerable<Teacher>> ReadAll() => _repository.ReadAll();

        public Task UpdateOne(Teacher teacher) => _repository.UpdateOne(teacher);

        public Task DeleteById(int id) => _repository.DeleteById(id);
    }
}
