using Microsoft.EntityFrameworkCore;
using watchdogplatform.entityframework.Models;

namespace watchdogplatform.entityframework
{
    public class WatchDogPlatformDbContext:DbContext
    {
        public WatchDogPlatformDbContext(DbContextOptions<WatchDogPlatformDbContext> options):base(options)
        {
            //use steps defined at
            // https://docs.microsoft.com/en-us/ef/core/providers/cosmos/?tabs=dotnet-core-cli
        }

        public virtual DbSet<Organization> Organizations { get; set; }
    }
}