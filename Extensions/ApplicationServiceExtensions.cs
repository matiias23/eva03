using Microsoft.EntityFrameworkCore;
using Api2.Data;

namespace Api2.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void SeedDatabase(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ItemContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            try
            {
                // Migrate the database, create if it doesn't exist
                context.Database.Migrate();
                Seed.SeedData(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, " A problem ocurred during seeding ");
            }
        }
    }
}