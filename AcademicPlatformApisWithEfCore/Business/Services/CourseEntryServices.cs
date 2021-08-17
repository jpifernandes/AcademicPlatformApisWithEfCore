using AcademicPlatformApisWithEfCore.Domain.Entities;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Repositories;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Business.Services
{
    public class CourseEntryServices : ICourseEntryServices
    {
        private readonly ICourseEntryRepository _repository;

        public CourseEntryServices(ICourseEntryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task AddOne(CourseEntry entry) => _repository.AddOne(entry);

        public Task AddMany(IEnumerable<CourseEntry> entries) => _repository.AddMany(entries);

        public Task<IEnumerable<CourseEntry>> ReadByCourse(int courseId) => _repository.ReadByCourse(courseId);

        public Task<IEnumerable<CourseEntry>> ReadByUser(int userId) => _repository.ReadByUser(userId);

        public Task DeleteById(int id) => _repository.DeleteById(id);
    }
}
