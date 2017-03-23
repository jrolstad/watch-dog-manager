using System;
namespace watch_dog_manager.mvc.core.mappers
{
	public class VolunteerMapper
	{
		public Models.api.Volunteer Map(core.EntityFramework.models.Volunteer toMap)
		{
			var result = new Models.api.Volunteer 
			{ 
				Id = toMap.Id,
				Name = toMap.Name
			};

			return result;
		}

		public core.EntityFramework.models.Volunteer Map(Models.api.Volunteer toMap)
		{
			var result = new core.EntityFramework.models.Volunteer
			{
				Id = toMap.Id,
				Name = toMap.Name
			};

			return result;
		}

		public core.EntityFramework.models.Volunteer MapExisting(core.EntityFramework.models.Volunteer existing, Models.api.Volunteer toMap)
		{
			return existing;
		}
	}
}
