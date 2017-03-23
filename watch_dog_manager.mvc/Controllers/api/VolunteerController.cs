using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using watch_dog_manager.mvc.core.EntityFramework;
using watch_dog_manager.mvc.core.mappers;
using watch_dog_manager.mvc.Models.api;

namespace watch_dog_manager.mvc
{
	public class VolunteerController:Controller
	{
		readonly WatchDogManagerDbContext _context;
		readonly VolunteerMapper _mapper;


		public VolunteerController(WatchDogManagerDbContext context, VolunteerMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("api/volunteer")]
		public IActionResult Get()
		{
			var result = _context.Volunteer
					 			 .Select(_mapper.Map)
								 .ToList();
			return Ok(result);
		}

		[HttpGet]
		[Route("api/volunteer/{id}")]
		public IActionResult Get(int id)
		{
			var result = _context.Volunteer
								 .Where(v => v.Id == id)
					 			 .Select(_mapper.Map)
								 .FirstOrDefault();

			if (result == null)
				return NotFound();

			return Ok(result);
		}

		[HttpPost]
		[Route("api/volunteer")]
		public IActionResult Create(Volunteer data)
		{
			var mappedItem = _mapper.Map(data);
			_context.Volunteer.Add(mappedItem);
			_context.SaveChanges();

			return Ok(mappedItem);
		}

		[HttpPut]
		[Route("api/volunteer")]
		public IActionResult Modify(Volunteer data)
		{
			var existing = _context.Volunteer
								 .FirstOrDefault(v => v.Id == data.Id);
			
			if (existing == null)
				return NotFound();

			var mappedItem = _mapper.MapExisting(existing, data);
			_context.SaveChanges();

			var result = _mapper.Map(existing);

			return Ok(mappedItem);
		}

		[HttpDelete]
		[Route("api/volunteer/{id}")]
		public IActionResult Delete(int id)
		{
			var existing = _context.Volunteer
								 .FirstOrDefault(v => v.Id == id);

			if (existing == null)
				return NotFound();

			_context.Volunteer.Remove(existing);
			_context.SaveChanges();
			
			return Ok();
		}

	}
}
