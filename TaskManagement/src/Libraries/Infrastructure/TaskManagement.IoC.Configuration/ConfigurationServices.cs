using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Core;
using TaskManagement.Core.Mapper;
using TaskManagement.Infrastructure;
using TaskManagement.Repositories.Base;
using TaskManagement.Repositories.Interface;

namespace TaskManagement.IoC.Configuration;

public static class ConfigurationServices
{
    public static IServiceCollection AddExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TaskManagementDbContext>(Options => Options.UseSqlServer(configuration.GetConnectionString("Conn")));

        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddAutoMapper(typeof(CommonMapper).Assembly);

        services.AddMediatR(options =>
        options.RegisterServicesFromAssemblies(typeof(ICore).Assembly));

        return services;
        


    }




}
