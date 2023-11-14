using System.Text.Json;
using System.Text.Json.Serialization;
namespace Qubi.Api.Controllers.Converters;

public sealed class InstantConverter : JsonConverter<Instant>
{
    public override Instant Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null)
            throw new JsonException("Value cannot be null.");

        return DateTime.TryParse(value, out var date)
            ? Instant.FromDateTimeUtc(date)
            : throw new JsonException("Invalid date");
    }

    public override void Write(Utf8JsonWriter writer, Instant value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value
            .ToDateTimeUtc()
            .ToString("O")
        );
    }
}