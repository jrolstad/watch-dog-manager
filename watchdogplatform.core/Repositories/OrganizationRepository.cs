using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using watchdogplatform.core.Models;
using watchdogplatform.entityframework;

namespace watchdogplatform.core.Repositories
{
    public class OrganizationRepository
    {
        private readonly ILogger _logger;
        private readonly WatchDogPlatformDbContext _context;


        public OrganizationRepository(ILogger<OrganizationRepository> logger, WatchDogPlatformDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<List<Organization>> Get()
        {
            return _context
                .Organizations
                .Select(o => MapToDomain(o))
                .AsNoTracking()
                .ToList();
        }

        public async Task<Organization> Save(Organization instance)
        {
            var existingItem = _context.Organizations.Find(instance.Id);
            if (existingItem == null)
            {
                instance.Id = Guid.NewGuid().ToString();
                var dataModel = MapToData(instance);
                _context.Organizations.Add(dataModel);
            }
            else
            {
                UpdateDataModel(existingItem,instance);
            }
                
            _context.SaveChanges();

            var savedData = _context.Organizations.Find(instance.Id);
            var savedDomain = MapToDomain(savedData);

            return savedDomain;
        }

        private static Organization MapToDomain(entityframework.Models.Organization toMap)
        {
            var domain = new Organization
            {
                Id = toMap.Id,
                Name = toMap.Name,
                AffiliatedWith = toMap.AffiliatedWith
            };

            return domain;
        }

        private static entityframework.Models.Organization MapToData(Organization toMap)
        {
            var dataModel = new entityframework.Models.Organization
            {
                Id = toMap.Id,
                Name = toMap.Name,
                AffiliatedWith = toMap.AffiliatedWith
            };

            return dataModel;
        }

        private static void UpdateDataModel(entityframework.Models.Organization toUpdate, Organization source)
        {
            toUpdate.Name = source.Name;
            toUpdate.AffiliatedWith = source.AffiliatedWith;
            
        }
    }
}