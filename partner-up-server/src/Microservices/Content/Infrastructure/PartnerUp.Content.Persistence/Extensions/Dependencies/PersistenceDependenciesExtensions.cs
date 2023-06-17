using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PartnerUp.Content.Persistence.Data;
using PartnerUp.Content.Persistence.Data.Repositories;
using PartnerUp.Content.Application.Interfaces.Data;
using PartnerUp.Content.Application.Interfaces.Data.Repositories;

namespace PartnerUp.Content.Persistence.Extensions.Dependencies;

public static class PersistenceDependenciesExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ContentDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        services.AddTransient<INotificationRepository, NotificationRepository>();
        services.AddTransient<INotificationTemplateRepository, NotificationTemplateRepository>();
        services.AddTransient<IRecentRequestRepository, RecentRequestRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
