using Microsoft.AspNetCore.Identity;

namespace Webion.Template.Storage.Data.Identity;

public sealed class RoleDbo : IdentityRole<Guid>
{
    public const string Admin = "Admin";
    public const string User = "User";
}