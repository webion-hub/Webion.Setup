using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Qubi.Api.Controllers.Errors;

public static class ModelStateDictionaryExtension
{
    public static ValidationError ToZod(this ModelStateDictionary modelState)
    {
        return ValidationError.FromModelState(modelState);
    }
}