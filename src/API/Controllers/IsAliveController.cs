using Elsekily.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Elsekily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class IsAliveController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Result<object>.Success(new { Status = "Alive", Time = DateTime.Now }));
    }
}
