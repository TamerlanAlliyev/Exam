using ExamApp.Application.Common.Mapping;
using ExamApp.Application.Repositories;
using ExamApp.Application.Repositoriesp;
using ExamApp.Application.Services;
using ExamApp.Infrastructure.Repositories;
using ExamApp.Infrastructure.Services;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
          configuration.GetConnectionString("MSSQL"),
          b => b.MigrationsAssembly("Infrastructure")
        ));


        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<ITeacherService, TeacherManager>();
        services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
        services.AddScoped<ISchoolClassService, SchoolClassManager>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentService, StudentManager>();

        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<ILessonService, LessonManager>();
        return services;
    }
}
