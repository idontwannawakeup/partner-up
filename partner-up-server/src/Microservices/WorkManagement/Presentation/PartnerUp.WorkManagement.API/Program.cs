using PartnerUp.Shared.Extensions;
using PartnerUp.WorkManagement.API.Extensions.Dependencies;
using PartnerUp.WorkManagement.API.Grpc;
using PartnerUp.WorkManagement.API.Middlewares;
using PartnerUp.WorkManagement.Application.Extensions.Dependencies;
using PartnerUp.WorkManagement.Persistence;
using PartnerUp.WorkManagement.Persistence.Extensions.Dependencies;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddCustomLogging(builder.Configuration,
    builder.Environment,
    "partner-up-work-management");

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddPresentation(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTwsSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

if (app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGrpcService<RecentService>();

await using (var scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetRequiredService<WorkManagementDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    var migrationSucceeded = await context.Database.TryMigrateAsync();
    if (!migrationSucceeded)
    {
        logger.LogError("Migration failed. Check connection to the server.");
    }
}

await app.RunAsync();
