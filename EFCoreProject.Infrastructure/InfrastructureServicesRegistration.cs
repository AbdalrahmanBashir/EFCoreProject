using EFCoreProject.Domain.Contracts;
using EFCoreProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreProject.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<PharmacyPrescriptionManagementSystemContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")));
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPharmaceuticalCompanyRepository, PharmaceuticalCompanyRepository>();
            services.AddScoped<IPharmacyRepository, PharmacyRepository>();
            return services;
        }
    }
}
