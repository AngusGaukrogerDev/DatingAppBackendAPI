using DatingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DatingApp.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<StandardApplicationUser> StandardApplicationUser { get; set; }
        public DbSet<UserLikesAndMatches> UserLikesAndMatches { get; set; }
    }
}
