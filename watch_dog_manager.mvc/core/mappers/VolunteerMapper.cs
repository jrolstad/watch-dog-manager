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
				Name = toMap.Name,
				Email = toMap.Email,
				PhoneNumber = toMap.PhoneNumber,
				Students = toMap.Students,
				Teachers = toMap.Teachers,
				LastBackgroundCheck = toMap.LastBackgroundCheck,
				KickoffAttendee = toMap.KickoffAttendee
			};

			return result;
		}

		public core.EntityFramework.models.Volunteer Map(Models.api.Volunteer toMap)
		{
			var result = new core.EntityFramework.models.Volunteer
			{
				Id = toMap.Id,
				Name = toMap.Name,
				Email = toMap.Email,
				PhoneNumber = toMap.PhoneNumber,
				Students = toMap.Students,
				Teachers = toMap.Teachers,
				LastBackgroundCheck = toMap.LastBackgroundCheck,
				KickoffAttendee = toMap.KickoffAttendee
			};

			return result;
		}

		public core.EntityFramework.models.Volunteer MapExisting(core.EntityFramework.models.Volunteer existing, Models.api.Volunteer toMap)
		{
			existing.Name = toMap.Name;
			existing.Email = toMap.Email;
			existing.PhoneNumber = toMap.PhoneNumber;
			existing.Students = toMap.Students;
			existing.Teachers = toMap.Teachers;
			existing.LastBackgroundCheck = toMap.LastBackgroundCheck;
			existing.KickoffAttendee = toMap.KickoffAttendee;
			                           
			return existing;
		}
	}
}
