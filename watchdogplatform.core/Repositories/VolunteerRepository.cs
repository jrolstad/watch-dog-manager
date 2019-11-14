using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using watchdogplatform.core.Models;
using watchdogplatform.entityframework;

namespace watchdogplatform.core.Repositories
{
    public class VolunteerRepository
    {
        private readonly ILogger _logger;
        private readonly WatchDogPlatformDbContext _context;


        public VolunteerRepository(ILogger<VolunteerRepository> logger, WatchDogPlatformDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<List<Volunteer>> Get()
        {
            return _context
                .Volunteers
                .Select(o => MapToDomain(o))
                .AsNoTracking()
                .ToList();
        }

        public async Task<Volunteer> Save(Volunteer instance)
        {
            var existingItem = _context.Volunteers.Find(instance.Id);
            if (existingItem == null)
            {
                instance.Id = Guid.NewGuid().ToString();
                var dataModel = MapToData(instance);
                _context.Volunteers.Add(dataModel);
            }
            else
            {
                UpdateDataModel(existingItem, instance);
            }

            await _context.SaveChangesAsync();

            var savedData = _context.Volunteers.Find(instance.Id);
            var savedDomain = MapToDomain(savedData);

            return savedDomain;
        }

        private static Volunteer MapToDomain(entityframework.Models.Volunteer toMap)
        {
            var domain = new Volunteer
            {
                Id = toMap.Id,
                Name = toMap.Name,
                Email = toMap.Email
            };

            return domain;
        }

        private static entityframework.Models.Volunteer MapToData(Volunteer toMap)
        {
            var dataModel = new entityframework.Models.Volunteer
            {
                Id = toMap.Id,
                Name = toMap.Name,
                Email = toMap.Email
            };

            return dataModel;
        }

        private static void UpdateDataModel(entityframework.Models.Volunteer toUpdate, Volunteer source)
        {
            toUpdate.Name = source.Name;
            toUpdate.Email = source.Email;

        }
    }
}