using AcademicPlatformApisWithEfCore.Domain.Interfaces.Mappers;
using AcademicPlatformApisWithEfCore.Mapper.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AcademicPlatformApisWithEfCore.Mapper
{
    public static class MapperProvider
    {
        public static IServiceCollection AddAutoMapperProvider(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(ConvertionProfile));
            services.AddTransient<IObjectConverter, AutoMapperObjectConverter>();

            return services;
        }
    }
}
