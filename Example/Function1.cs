
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Example.Persistence;

namespace Example
{
    public class Function1
    {
        private readonly AppContext _context;

        public Function1(AppContext context)
        {
            _context = context;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            await _context.Persons.AddAsync(new Domain.Entities.Person { Name = "John"});
            await _context.SaveChangesAsync();
            return new OkObjectResult($"OK");
        }
    }
}
