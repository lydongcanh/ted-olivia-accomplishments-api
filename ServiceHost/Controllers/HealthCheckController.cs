using Microsoft.AspNetCore.Mvc;

namespace TedOliviaAccomplishmentsApi.ServiceHost.Controllers;

[ApiController]
public class HealthCheckController : ControllerBase
{
    [HttpGet("api/v1/healthz")]
    public IActionResult Healthz()
    {
        return Ok();
    }
}