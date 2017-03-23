using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using watch_dog_manager.mvc.core.EntityFramework;
using watch_dog_manager.mvc.core.mappers;
using Microsoft.Extensions.Configuration;

namespace watch_dog_manager.mvc.core.dependency_injection
{
	public class RegistrationModule
	{
		public static void Register(IServiceCollection services, IConfigurationRoot configuration)
		{
			//services.AddDbContext<WatchDogManagerDbContext>(options =>
			//	options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddDbContext<WatchDogManagerDbContext>(options =>
			   options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

			services.AddTransient<VolunteerMapper>();

		}
	}
}
