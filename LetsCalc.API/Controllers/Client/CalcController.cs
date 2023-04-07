using LetsCalc.API.Client.Nums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LetsCalc.API.Controllers.Client;

public class CalcController : AbstractController
{
    private readonly ILogger<CalcController> _logger;
    
    public CalcController(ILogger<CalcController> logger)
    {
        _logger = logger;
    }
    
    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Addition([FromBody] Nums request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var sum = (request.A + request.B);
        _logger.LogDebug("Sum {a}+{b} is {s}", request.A, request.B, sum);
        return Ok(sum);
    }
}