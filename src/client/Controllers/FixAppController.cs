using Microsoft.AspNetCore.Mvc;

namespace client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FixAppController : ControllerBase
    {

        private readonly ILogger<FixAppController> _logger;

        public FixAppController(ILogger<FixAppController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "test-connection")]
        public IEnumerable<int> Get()
        {
            return Enumerable.Range(1, 5);
        }
    }
}
