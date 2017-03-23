using System;
using Microsoft.EntityFrameworkCore;

namespace watch_dog_manager.mvc.core.EntityFramework
{
	public class WatchDogManagerDbContext:DbContext
	{
		public WatchDogManagerDbContext(DbContextOptions<WatchDogManagerDbContext> options) : base(options)
        {
			
		}

		public DbSet<models.Volunteer> Volunteer { get;set; }
	}
}
