using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Visions.Domain.Interfaces;
using Visions.Infrastructure.Database;
using Visions.Infrastructure.Database.Repositories;

namespace Visions.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddFluenteMigration(services, configuration);
        }         
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            services.AddDbContext<VisionsDbContext>(dbContext =>
            {
                dbContext.UseSqlServer(connectionString);
            }); 
        }   
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ILivroRepository, LivroRepository>();    
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();

        }
        private static void AddFluenteMigration(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            services.AddFluentMigratorCore().ConfigureRunner(opt =>
            {
                opt.AddSqlServer()
                   .WithGlobalConnectionString(connectionString)
                   .ScanIn(Assembly.Load("Visions.Infrastructure")).For.All();
            });
        }
    }
}
