using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    private readonly DemoConfig _config;
    public DemoController(IOptions<DemoConfig> config)
        => _config = config.Value;


    [HttpGet]
    public IActionResult Get()
    {
        var value = _config.DemoProperty;

        return Ok(value);
    }
}
