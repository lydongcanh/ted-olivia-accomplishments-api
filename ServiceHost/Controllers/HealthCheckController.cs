using Microsoft.AspNetCore.Mvc;

namespace TedOliviaAccomplishmentsApi.ServiceHost.Controllers;

[ApiController]
public class HealthCheckController : ControllerBase
{
    [HttpGet("api/v1/heathz")]
    public IActionResult Heathz()
    {
        return Ok();
    }
}
