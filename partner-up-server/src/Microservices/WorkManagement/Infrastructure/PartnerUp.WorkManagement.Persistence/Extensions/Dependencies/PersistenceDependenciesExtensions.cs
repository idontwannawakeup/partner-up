using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PartnerUp.WorkManagement.Persistence.Data;
using PartnerUp.WorkManagement.Persistence.Data.Repositories;
using PartnerUp.WorkManagement.Persistence.Data.Seeders;
using PartnerUp.Shared.Filters;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.WorkManagement.Application.Interfaces.Data;
using PartnerUp.WorkManagement.Application.Interfaces.Data.Repositories;
using PartnerUp.WorkManagement.Application.Interfaces.Data.Seeders;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Persistence.Common.Factories.FilterFactories;

namespace PartnerUp.WorkManagement.Persistence.Extensions.Dependencies;

public static class PersistenceDependenciesExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<WorkManagementDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        services.AddTransient<IProjectsRepository, ProjectsRepository>();
        services.AddTransient<ITeamsRepository, TeamsRepository>();
        services.AddTransient<ITicketsRepository, TicketsRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        // services.AddTransient<IFilterCriteriaFactory, FilterCriteriaFactory>();
        services.AddTransient<IFilterFactory<Project>, ProjectFilterFactory>();
        services.AddTransient<IFilterFactory<Team>, TeamFilterFactory>();
        services.AddTransient<IFilterFactory<Ticket>, TicketFilterFactory>();

        services.AddTransient<IUserProfileSeeder, UserProfileSeeder>();
        services.AddTransient<IProjectSeeder, ProjectSeeder>();
        services.AddTransient<ITeamSeeder, TeamSeeder>();
        services.AddTransient<ITeamsMembersSeeder, TeamsMembersSeeder>();
        services.AddTransient<ITicketSeeder, TicketSeeder>();

        return services;
    }
}
