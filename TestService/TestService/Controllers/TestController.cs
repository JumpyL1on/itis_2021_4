using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestService.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class TestController : ControllerBase
    {
        private HttpClient HttpClient { get; }

        public TestController(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        [HttpPost]
        public async Task Post()
        {
            await using var writer = new StreamWriter("test.txt", true);
            var url = "https://microservices-homework1.herokuapp.com/api/User/GetRolesByLoginOrEmail?login=Admin";
            var result = await HttpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var roles = await result.Content.ReadFromJsonAsync<string[]>();
                if (roles != null)
                    foreach (var role in roles)
                        await writer.WriteLineAsync(role);
            }
        }
    }
}
