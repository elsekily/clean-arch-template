using Elsekily.Application.Features.IsAlive.Queries.GetIsAlive;
using Microsoft.AspNetCore.Mvc;

namespace Elsekily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class IsAliveController(IGetIsAliveQuery getIsAliveQuery) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await getIsAliveQuery.ExecuteAsync());
    }
}
