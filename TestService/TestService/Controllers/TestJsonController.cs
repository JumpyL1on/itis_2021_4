using Microsoft.AspNetCore.Mvc;
using TestService.Services;

namespace TestService.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class TestJsonController : ControllerBase
    {
        private ITestService TestService { get; }

        public TestJsonController(ITestService testService)
        {
            TestService = testService;
        }
        
        [HttpGet]
        [Route("json1")]
        public ActionResult<object> Get()
        {
            return Ok(TestService.GetTestJson("str"));
        }
    }
}