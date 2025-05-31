using Microsoft.EntityFrameworkCore;
using PlanBrowserAPI.Models;

namespace PlanBrowserAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plan> Plans => Set<Plan>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
