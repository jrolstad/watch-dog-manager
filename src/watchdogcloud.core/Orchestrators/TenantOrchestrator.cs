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

        public Tenant Get(string id) 
        { 
            return repository.Get(id); 
        }

        public Tenant Create(Tenant toCreate)
        {
            return repository.Create(toCreate);
        }

        public Tenant Update(Tenant toUpdate)
        {
            return repository.Update(toUpdate);
        }

        public void Delete(string id)
        {
            repository.Delete(id);
        }
    }
}
