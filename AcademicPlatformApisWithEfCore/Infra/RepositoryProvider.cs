using AcademicPlatformApisWithEfCore.Infra.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AcademicPlatformApisWithEfCore.Infra
{
    public static class RepositoryProvider
    {
        public static IServiceCollection AddSqlServerWithEfCoreRepository(this IServiceCollection services, string connectionString)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"Argument {nameof(connectionString)} can not be null or empty.");

            services.AddDbContext<EfContext>(configuration =>
            {
                configuration.UseSqlServer(connectionString, options =>
                {
                    options.EnableRetryOnFailure(maxRetryCount: 3,
                                                 maxRetryDelay: TimeSpan.FromSeconds(5),
                                                 errorNumbersToAdd: null);
                });
            });

            return services;
        }
    }
}
