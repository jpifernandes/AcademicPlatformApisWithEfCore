using AcademicPlatformApisWithEfCore.Domain.Entities;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Repositories;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Business.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly ICourseRepository _repository;

        public CourseServices(ICourseRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task AddOne(Course course) => _repository.AddOne(course);

        public Task AddMany(IEnumerable<Course> courses) => _repository.AddMany(courses);

        public Task<Course> ReadById(int id) => _repository.ReadById(id);

        public Task<IEnumerable<Course>> ReadAll() => _repository.ReadAll();

        public Task UpdateOne(Course course) => _repository.UpdateOne(course);

        public Task DeleteById(int id) => _repository.DeleteById(id);
    }
}
