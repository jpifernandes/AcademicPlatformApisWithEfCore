using AcademicPlatformApisWithEfCore.Business.Services;
using AcademicPlatformApisWithEfCore.Infra;
using AcademicPlatformApisWithEfCore.Infra.EfCore.Repositories;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Repositories;
using AcademicPlatformApisWithEfCore.Domain.Interfaces.Services;
using AcademicPlatformApisWithEfCore.Domain.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AcademicPlatformApisWithEfCore.Mapper;

namespace AcademicPlatformApisWithEfCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Academic Platform APIs with EF Core", Version = "v1" });
            });

            #region Database

            DbSettings dbSettings = Configuration.GetSection("DbSettings").Get<DbSettings>();
            services.AddSqlServerWithEfCoreRepository(dbSettings.ConnectionString);

            #endregion

            #region Mapper

            services.AddAutoMapperProvider();

            #endregion

            #region DI

            services.AddScoped<IUserRepository, UserRepository>()
                    .AddScoped<ITeacherRepository, TeacherRepository>()
                    .AddScoped<ICourseRepository, CourseRepository>()
                    .AddScoped<ICourseEntryRepository, CourseEntryRepository>()
                    .AddScoped<IUserServices, UserServices>()
                    .AddScoped<ITeacherServices, TeacherServices>()
                    .AddScoped<ICourseServices, CourseServices>()
                    .AddScoped<ICourseEntryServices, CourseEntryServices>();

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())           
                app.UseDeveloperExceptionPage();

            app.UseSwagger()
               .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AcademicPlatformApisWithEfCore v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
