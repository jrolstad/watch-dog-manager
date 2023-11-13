using watchdogcloud.core.Models;

namespace watchdogcloud.core.Orchestrators
{
    public class TenantOrchestrator
    {
        public List<Tenant> Get() {  return new List<Tenant> { Get("id1")}; }

        public Tenant Get(string id) { return new Tenant(id, "Number one", "one"); }

        public Tenant Create(Tenant toCreate)
        {
            return new Tenant(Guid.NewGuid().ToString(), toCreate.Name, toCreate.Code);
        }

        public Tenant Update(Tenant toUpdate)
        {
            return toUpdate;
        }

        public void Delete(string id)
        {

        }
    }
}
