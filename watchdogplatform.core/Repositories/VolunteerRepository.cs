using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using watchdogplatform.core.Models;

namespace watchdogplatform.core.Repositories
{
    public class VolunteerRepository
    {
        private readonly ILogger<VolunteerRepository> _logger;

        private List<Volunteer> _data = new List<Volunteer>();

        public VolunteerRepository(ILogger<VolunteerRepository> logger)
        {
            _logger = logger;
            _data.Add(new Volunteer());
        }
        public async Task<List<Volunteer>> Get()
        {
            _logger.LogInformation("Obtaining all volunteers");
            return _data;
        }

        public async Task<Volunteer> Save(Volunteer instance)
        {
            _logger.LogInformation($"Saving volunteer '{instance.Name}'");

            var existingItem = _data.FirstOrDefault(v => v.Id == instance.Id);

            if (existingItem == null)
            {
                instance.Id = Guid.NewGuid().ToString();
                _data.Add(instance);
            }
            else
            {
                _data.Remove(existingItem);
                _data.Add(instance);
            }

            return instance;
        }
    }
}