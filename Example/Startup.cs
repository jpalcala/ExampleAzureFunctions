using Example;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Example.Persistence;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Example
{
    class Startup : FunctionsStartup
    {

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<AppContext>(options => options.UseSqlite("Filename=TestDatabase.db"));

            using (var context = new AppContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
