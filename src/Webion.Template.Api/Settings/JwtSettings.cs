namespace Qubi.Api.Settings;

public sealed class JwtSettings
{
    public const string Section = "Jwt";
    public required string Issuer { get; init; }
    public required string[] Audiences { get; init; }
    public required string Secret { get; init; }
}