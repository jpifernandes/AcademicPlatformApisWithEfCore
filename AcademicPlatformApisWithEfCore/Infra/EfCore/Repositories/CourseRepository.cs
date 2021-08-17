using AcademicPlatformApisWithEfCore.Domain.Entities;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Infra.EfCore.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly EfContext _dbContext;
        private readonly DbSet<Course> _dbSet;

        public CourseRepository(EfContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<Course>();
        }

        public async Task AddOne(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            await _dbSet.AddAsync(course).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task AddMany(IEnumerable<Course> courses)
        {
            if (courses == null || !courses.Any())
                throw new ArgumentException($"Argument {nameof(courses)} can not be null or empty.");

            await _dbSet.AddRangeAsync(courses).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public Task<Course> ReadById(int id)
            => _dbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<Course>> ReadAll()
        {
            IEnumerable<Course> courses = await _dbSet.AsNoTracking().ToArrayAsync().ConfigureAwait(false);
            return courses;
        }

        public Task UpdateOne(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            _dbSet.Update(course);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            _dbSet.Remove(new Course { Id = id });
            return _dbContext.SaveChangesAsync();
        }
    }
}
