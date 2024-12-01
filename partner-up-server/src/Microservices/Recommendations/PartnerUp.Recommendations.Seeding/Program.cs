using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PartnerUp.Identity.Persistence.People;
using PartnerUp.Identity.Persistence.People.Common.Factories.FilterFactories;
using PartnerUp.Identity.Persistence.People.Data.Entities;
using PartnerUp.Identity.Persistence.People.Data.Repositories;
using PartnerUp.Identity.Persistence.People.Interfaces.Data.Repositories;
using PartnerUp.Recommendations.Seeding;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.Social.DataAccess;
using PartnerUp.Social.DataAccess.Data.Repositories;
using PartnerUp.Social.DataAccess.Data.Seeders;
using PartnerUp.Social.DataAccess.Interfaces.Data.Repositories;
using PartnerUp.Social.DataAccess.Interfaces.Data.Seeders;
using PartnerUp.WorkManagement.Application.Extensions.Dependencies;
using PartnerUp.WorkManagement.Application.Interfaces.Data.Repositories;
using PartnerUp.WorkManagement.Application.Interfaces.Data.Seeders;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Persistence;
using PartnerUp.WorkManagement.Persistence.Common.Factories.FilterFactories;
using PartnerUp.WorkManagement.Persistence.Data.Repositories;
using PartnerUp.WorkManagement.Persistence.Data.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PeopleDbContext>(options =>
{
    const string connectionString = "Server=localhost,14330;Database=PartnerUpPeople;User=sa;Password=YourStrong@Passw0rd;";
    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<Guid>>()
    .AddSignInManager<SignInManager<User>>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<PeopleDbContext>();

builder.Services.AddAuthentication();

builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<PartnerUp.Identity.Persistence.People.Interfaces.Data.IUnitOfWork, PartnerUp.Identity.Persistence.People.Data.UnitOfWork>();

builder.Services.AddTransient<IFilterFactory<User>, UserFilterFactory>();

//

builder.Services.AddDbContext<WorkManagementDbContext>(options =>
{
    const string connectionString = "Server=localhost,14330;Database=PartnerUpWorkManagement;User=sa;Password=YourStrong@Passw0rd;";
    options.UseSqlServer(connectionString);
});

builder.Services.AddTransient<IProjectsRepository, ProjectsRepository>();
builder.Services.AddTransient<ITeamsRepository, TeamsRepository>();
builder.Services.AddTransient<ITicketsRepository, TicketsRepository>();
builder.Services.AddTransient<PartnerUp.WorkManagement.Application.Interfaces.Data.IUnitOfWork, PartnerUp.WorkManagement.Persistence.Data.UnitOfWork>();

builder.Services.AddTransient<IFilterFactory<Project>, ProjectFilterFactory>();
builder.Services.AddTransient<IFilterFactory<Team>, TeamFilterFactory>();
builder.Services.AddTransient<IFilterFactory<Ticket>, TicketFilterFactory>();

builder.Services.AddTransient<PartnerUp.WorkManagement.Application.Interfaces.Data.Seeders.IUserProfileSeeder, PartnerUp.WorkManagement.Persistence.Data.Seeders.UserProfileSeeder>();
builder.Services.AddTransient<IProjectSeeder, ProjectSeeder>();
builder.Services.AddTransient<ITeamSeeder, TeamSeeder>();
builder.Services.AddTransient<ITeamsMembersSeeder, TeamsMembersSeeder>();
builder.Services.AddTransient<ITicketSeeder, TicketSeeder>();

//

{
    var socialConnectionString = "Server=localhost,14330;Database=PartnerUpSocial;User=sa;Password=YourStrong@Passw0rd;";
    builder.Services.AddTransient<IDbConnection>(_ => new SqlConnection(socialConnectionString));
    builder.Services.AddDbContext<SocialDbContext>(options =>
    {
        options.UseSqlServer(socialConnectionString);
    });

    builder.Services.AddTransient<IFriendsRepository, FriendsRepository>();
    builder.Services.AddTransient<IRatingsRepository, RatingsRepository>();
    builder.Services.AddTransient<PartnerUp.Social.DataAccess.Interfaces.Data.IUnitOfWork, PartnerUp.Social.DataAccess.Data.UnitOfWork>();
    
    builder.Services.AddTransient<IRatingSeeder, RatingSeeder>();
    builder.Services.AddTransient<PartnerUp.Social.DataAccess.Interfaces.Data.Seeders.IUserProfileSeeder, PartnerUp.Social.DataAccess.Data.Seeders.UserProfileSeeder>();
}


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var seed = true;
if (seed)
{
    await using var scope = app.Services.CreateAsyncScope();
    var context = scope.ServiceProvider.GetRequiredService<PeopleDbContext>();
    var workContext = scope.ServiceProvider.GetRequiredService<WorkManagementDbContext>();
    var socialContext = scope.ServiceProvider.GetRequiredService<SocialDbContext>();
    UserSeeder.SeedUsersForRecommendations(context, workContext, socialContext);
    await context.SaveChangesAsync();
    await workContext.SaveChangesAsync();
    await socialContext.SaveChangesAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
