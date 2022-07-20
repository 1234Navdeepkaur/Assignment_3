using BusManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace BusManagement.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new BusManagementContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BusManagementContext>>()))
            {
                // Look for any buses.
                if (context.Bus.Any())
                {
                    return;   // DB has been seeded
                }

                context.AddRange(
                    new Roadroute
                    {
                        FromLocation = "Barrie",
                        ToLocation = "Coldwater",
                        FairPrice = 4
                    }
                );
                context.SaveChanges();

                context.Bus.AddRange(
                    new Bus
                    {
                        Manufacturer = "GO",
                        Seats = 38,
                        Routeid = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
