using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using WatchDogManager.EntityFramework;

namespace WatchDogManager.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            MigrateDatabase();
        }

        private void MigrateDatabase()
        {
            var context = new WatchDogManagerDbContext();
            context.Migrate();
        }
    }
}
