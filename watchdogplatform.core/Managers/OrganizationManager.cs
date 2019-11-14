using System.Collections.Generic;
using System.Threading.Tasks;
using watchdogplatform.core.Models;
using watchdogplatform.core.Repositories;

namespace watchdogplatform.core.Managers
{
    public class OrganizationManager
    {
        private readonly OrganizationRepository _repository;

        public OrganizationManager(OrganizationRepository repository)
        {
            _repository = repository;
        }
        public async Task<IReadOnlyCollection<Organization>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Organization> Save(Organization organization)
        {
            return await _repository.Save(organization);
        }
    }
}