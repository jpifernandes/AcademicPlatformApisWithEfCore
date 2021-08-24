using AcademicPlatformApisWithEfCore.Infra.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AcademicPlatformApisWithEfCore.Infra
{
    public static class RepositoryProvider
    {
        public static IServiceCollection AddSqlServerWithEfCoreRepository(this IServiceCollection services, EfSettings settings)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            services.AddDbContext<EfContext>(configuration =>
            {
                configuration.UseSqlServer(settings.ConnectionString, options =>
                {
                    options.EnableRetryOnFailure(maxRetryCount: 3,
                                                 maxRetryDelay: TimeSpan.FromSeconds(5),
                                                 errorNumbersToAdd: null);
                });

                if(settings.EnableConsoleLog)
                    configuration.LogTo(Console.WriteLine, LogLevel.Information);
            });

            if(settings.RunMigrations)
            {
                EfContext dbContext = services.BuildServiceProvider().GetRequiredService<EfContext>();
                dbContext.Database.Migrate();
            }

            return services;
        }
    }
}
