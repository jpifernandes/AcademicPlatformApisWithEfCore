using AcademicPlatformApisWithEfCore.Domain.Entities;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicPlatformApisWithEfCore.Infra.EfCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EfContext _dbContext;
        private readonly DbSet<User> _dbSet;

        public UserRepository(EfContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<User>();
        }

        public async Task AddOne(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await _dbSet.AddAsync(user).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task AddMany(IEnumerable<User> users)
        {
            if (users == null || !users.Any())
                throw new ArgumentException($"Argument {nameof(users)} can not be null or empty.");

            await _dbSet.AddRangeAsync(users).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public Task<User> ReadById(int id)
             => _dbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

        public async Task<IEnumerable<User>> ReadAll()
        {
            IEnumerable<User> users = await _dbSet.AsNoTracking().ToArrayAsync().ConfigureAwait(false);
            return users;
        }

        public Task UpdateOne(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _dbSet.Update(user);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            _dbSet.Remove(new User { Id = id });
            return _dbContext.SaveChangesAsync();
        }
    }
}
