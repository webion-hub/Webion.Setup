using System.Text.Json;
using System.Text.Json.Serialization;
namespace Qubi.Api.Controllers.Converters;

public sealed class TimeOnlyConverter : JsonConverter<TimeOnly>
{
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null)
            throw new JsonException("Value cannot be null.");

        return DateTime.TryParse(value, out var r)
            ? TimeOnly.FromDateTime(r)
            : TimeOnly.Parse(value);
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        var date = DateTime.UnixEpoch + value.ToTimeSpan();
        writer.WriteStringValue(date.ToString("s"));
    }
}