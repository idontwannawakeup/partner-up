using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PartnerUp.Shared.Extensions;

public static class EntityFrameworkExtensions
{
    public static async Task<bool> TryMigrateAsync(
        this DatabaseFacade database,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await database.MigrateAsync(cancellationToken);
            return true;
        }
        catch (Microsoft.Data.SqlClient.SqlException)
        {
            return false;
        }
    }
}
