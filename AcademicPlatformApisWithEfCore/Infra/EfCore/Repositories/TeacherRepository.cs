using AcademicPlatformApisWithEfCore.Domain.Entities;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Infra.EfCore.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly EfContext _dbContext;
        private readonly DbSet<Teacher> _dbSet;

        public TeacherRepository(EfContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<Teacher>();
        }

        public async Task AddOne(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            await _dbSet.AddAsync(teacher).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task AddMany(IEnumerable<Teacher> teachers)
        {
            if (teachers == null || !teachers.Any())
                throw new ArgumentException($"Argument {nameof(teachers)} can not be null or empty.");

            await _dbSet.AddRangeAsync(teachers).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public Task<Teacher> ReadById(int id)
            => _dbSet.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        public async Task<IEnumerable<Teacher>> ReadAll()
        {
            IEnumerable<Teacher> teachers = await _dbSet.AsNoTracking().ToArrayAsync().ConfigureAwait(false);
            return teachers;
        }

        public Task UpdateOne(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            _dbSet.Update(teacher);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            _dbSet.Remove(new Teacher { Id = id });
            return _dbContext.SaveChangesAsync();
        }
    }
}
