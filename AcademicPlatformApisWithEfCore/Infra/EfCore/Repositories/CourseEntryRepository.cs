using AcademicPlatformApisWithEfCore.Domain.Entities;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Infra.EfCore.Repositories
{
    public class CourseEntryRepository : ICourseEntryRepository
    {
        private readonly EfContext _dbContext;
        private readonly DbSet<CourseEntry> _dbSet;

        public CourseEntryRepository(EfContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<CourseEntry>();
        }

        public async Task AddOne(CourseEntry entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            await _dbSet.AddAsync(entry).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task AddMany(IEnumerable<CourseEntry> entries)
        {
            if (entries == null || !entries.Any())
                throw new ArgumentException($"Argument {nameof(entries)} can not be null or empty.");

            await _dbSet.AddRangeAsync(entries).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public Task<IEnumerable<CourseEntry>> ReadByCourse(int courseId)
        {
            IEnumerable<CourseEntry> entries = _dbSet.AsNoTracking().Where(e => e.CourseId == courseId);
            return Task.FromResult(entries);
        }

        public Task<IEnumerable<CourseEntry>> ReadByUser(int userId)
        {
            IEnumerable<CourseEntry> entries = _dbSet.AsNoTracking().Where(e => e.UserId == userId);
            return Task.FromResult(entries);
        }

        public Task DeleteById(int id)
        {
            _dbSet.Remove(new CourseEntry { Id = id });
            return _dbContext.SaveChangesAsync();
        }
    }
}
