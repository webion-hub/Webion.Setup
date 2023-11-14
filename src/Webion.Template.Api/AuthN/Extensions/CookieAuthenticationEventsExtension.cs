using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace Qubi.Api.AuthN.Extensions;

public static class CookieAuthenticationEventsExtension
{
    public static void UseStatusCodeHandlers(this CookieAuthenticationEvents events)
    {
        events.OnRedirectToLogin = c => SetStatus(c, 401);
        events.OnRedirectToLogout = c => SetStatus(c, 204);
        events.OnRedirectToAccessDenied = c => SetStatus(c, 403);
        return;

        static Task SetStatus(BaseContext<CookieAuthenticationOptions> context, int statusCode)
        {
            context.Response.StatusCode = statusCode;
            return Task.CompletedTask;
        }
    }
}