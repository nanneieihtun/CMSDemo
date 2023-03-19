using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAdmin.Models
{
    public class SeedData
    {        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HotelDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HotelDBContext>>()))
            {
                // Look for any PhotoLists.
                if (context.Reservations.Any())
                {
                    return;   // DB has been seeded
                }

                context.SaveChanges();
            }
        }
    }
}