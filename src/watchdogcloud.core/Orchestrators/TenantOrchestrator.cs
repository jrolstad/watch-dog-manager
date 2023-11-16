using watchdogcloud.core.Models;
using watchdogcloud.core.Repositories;

namespace watchdogcloud.core.Orchestrators
{
    public class TenantOrchestrator
    {
        private readonly TenantRepository repository;

        public TenantOrchestrator(TenantRepository repository)
        {
            this.repository = repository;
        }

        public List<Tenant> Get() 
        {  
            return repository.Get(); 
        }

        public Task<Tenant> Get(string id) 
        { 
            return repository.Get(id); 
        }

        public Task<Tenant> Create(Tenant toCreate)
        {
            return repository.Create(toCreate);
        }

        public Task<Tenant> Update(Tenant toUpdate)
        {
            return repository.Update(toUpdate);
        }

        public Task Delete(string id)
        {
            return repository.Delete(id);
        }
    }
}
