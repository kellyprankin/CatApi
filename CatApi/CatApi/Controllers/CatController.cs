using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly ILogger<CatController> logger;

        public CatController(ILogger<CatController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization
                      = new AuthenticationHeaderValue("x-api-key", "398e462a-71f8-4e50-96d9-174021efeb08");

            var breedResponse = await httpClient.GetAsync("https://api.thecatapi.com/v1/breeds");
            var breedInfo = await breedResponse.Content.ReadAsStringAsync();

            return Ok(breedInfo);
        }
    }
}