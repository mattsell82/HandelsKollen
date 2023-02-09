using BlazorTimeCalculator.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorTimeCalculator.Data
{ 
    public class ApplicationDbContext : DbContext
    {
        public DbSet<WorkReport> WorkReports { get; set; }
        public DbSet<WorkUnit> WorkUnits { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=TimeDb.db");
    }
}