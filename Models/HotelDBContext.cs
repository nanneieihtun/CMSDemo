using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAdmin.Models
{
    public class HotelDBContext : DbContext
    {
        public HotelDBContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<AdminUser> AdminUsers { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<PhotoList> PhotoLists { get; set; }
    }
}
