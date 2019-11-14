using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using watchdogplatform.core.Models;

namespace watchdogplatform.core.Repositories
{
    public class VolunteerRepository
    {
        private readonly ILogger<VolunteerRepository> _logger;

        public VolunteerRepository(ILogger<VolunteerRepository> logger)
        {
            _logger = logger;
        }
        public async Task<List<Volunteer>> Get()
        {
            _logger.LogInformation("Obtaining all volunteers");
            return new List<Volunteer> {new Volunteer {Name = "the-one"}};
        }

        public async Task<Volunteer> Save(Volunteer data)
        {
            _logger.LogInformation($"Saving volunteer '{data.Name}'");
            return data;
        }
    }
}