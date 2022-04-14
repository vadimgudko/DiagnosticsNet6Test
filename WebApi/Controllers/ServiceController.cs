using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(ILogger<ServiceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
            //Activity.TraceIdGenerator += () =>
            //{
            //    return ActivityTraceId.CreateFromString("123");
            //};

            var activity = Activity.Current;
            var traceID = activity.TraceId;
            var headers = HttpContext.Request.Headers;
        }
    }
}