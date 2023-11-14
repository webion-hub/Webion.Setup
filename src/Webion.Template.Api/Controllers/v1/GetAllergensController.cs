namespace Qubi.Api.Controllers.v1;

[ApiController]
[Route("v{version:apiVersion}/example")]
[ApiVersion("1.0")]
[Tags("Example")]
public sealed class GetAllergensController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<IActionResult> ExampleAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(100, cancellationToken);

        return Ok();
    }
}