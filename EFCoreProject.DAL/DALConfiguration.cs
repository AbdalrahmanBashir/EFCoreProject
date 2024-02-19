using EFCoreProject.DAL.Repositories;
using EFCoreProject.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.DAL
{
    public static class DALConfiguration
    {
        public static IServiceCollection AddDLA(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")));
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            return services;
        }
    }
}
