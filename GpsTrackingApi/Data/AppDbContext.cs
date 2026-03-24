using GpsTrackingApi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GpsTrackingApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Location> Locations { get; set; }
    }
}
