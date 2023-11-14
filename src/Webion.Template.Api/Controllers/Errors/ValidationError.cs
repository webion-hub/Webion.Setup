using Humanizer;

using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Qubi.Api.Controllers.Errors;

public sealed class ValidationError
{
    public required DateTime Timestamp { get; init; }
    public required IEnumerable<ZodIssue> Issues { get; init; }

    public static IActionResult GenerateBadRequest(ActionContext context)
    {
        return new BadRequestObjectResult(FromModelState(context.ModelState));
    }

    public static ValidationError FromModelState(ModelStateDictionary modelState) => new()
    {
        Timestamp = DateTime.UtcNow,
        Issues = modelState
            .Where(m => m.Value is not null)
            .SelectMany(m => m.Value!.Errors.Select(e => new ZodIssue
            {
                Message = e.ErrorMessage,
                Path = m.Key
                    .Split('.', StringSplitOptions.RemoveEmptyEntries)
                    .Select(k => k.Camelize()),
            }))
    };
}