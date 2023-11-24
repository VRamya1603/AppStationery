using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppStationery.Model;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppStationery.Model.PrintingStationery> PrintingStationery { get; set; } = default!;

        public DbSet<AppStationery.Model.StationeryQuote> StationeryQuote { get; set; } = default!;

        public DbSet<AppStationery.Model.Branch> Branch { get; set; } = default!;

        public DbSet<AppStationery.Model.ApplicationUser> ApplicationUser { get; set; } = default!;
    }
