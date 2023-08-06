using HR.LeaveManagement.Peresistence.DatabaseContext;
using HR.LeaveManagement.Peresistence.Repositories;
using HR.LeaveveManagement.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Peresistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration confiuration)
    {
        services.AddDbContext<HrDatabaseContext>(
            options => {
                options.UseSqlServer(confiuration.GetConnectionString("HrDatabaseConnectionString"));
            } );

        services.AddScoped(typeof(IGenericRepository<>), typeof(IGenericRepository<>));
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveAllocationRepository,LeaveAllocationtRepository>();
        services.AddScoped<ILeaveRequestRepository,LeaveRequestRepository>();   

        return services;
    }
}

