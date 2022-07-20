using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusManagement.Models;

namespace BusManagement.Data
{
    public class BusManagementContext : DbContext
    {
        public BusManagementContext (DbContextOptions<BusManagementContext> options)
            : base(options)
        {
        }

        public DbSet<BusManagement.Models.Bus> Bus { get; set; } = default!;

        public DbSet<BusManagement.Models.Roadroute>? Roadroute { get; set; }
    }
}
