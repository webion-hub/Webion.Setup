namespace Qubi.Api.Controllers.Errors;

/// <summary>
/// Dto compliant with the zod library.
/// </summary>
public sealed class ZodIssue
{
    public required string Message { get; init; }
    public required IEnumerable<string> Path { get; init; }
    public string Code => "custom";
    public string Validation => "backend";
}
