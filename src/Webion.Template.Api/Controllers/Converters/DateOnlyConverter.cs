using System.Text.Json;
using System.Text.Json.Serialization;
namespace Qubi.Api.Controllers.Converters;

public sealed class DateOnlyConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null)
            throw new JsonException("Value cannot be null.");

        return DateTime.TryParse(value, out var r)
            ? DateOnly.FromDateTime(r)
            : DateOnly.Parse(value);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value
            .ToDateTime(new TimeOnly())
            .ToString("s")
        );
    }
}