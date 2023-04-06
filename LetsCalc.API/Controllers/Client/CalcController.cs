using Microsoft.AspNetCore.Mvc;

namespace LetsCalc.API.Controllers.Client;

public class CalcController : AbstractController
{
    private readonly ILogger<CalcController> _logger;

    public CalcController(ILogger<CalcController> logger)
    {
        _logger = logger;
    }


    [HttpPut]
    public async Task<IActionResult> Addition(int a, int b)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var sum = (a + b);
        _logger.LogInformation("Sum {a}+{b} is {s}", a, b, sum);
        return Ok(sum);
    }
}