using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mastonet;

public class JsonEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var val = reader.GetString()?.Replace("_", "");
        var result = Enum.Parse(typeof(T), val, true);

        return (T)result;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        // PascalCase to snake_case
        var val = value.ToString();
        var snakeCase = string.Concat(val.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : x.ToString())).ToLower();
        writer.WriteStringValue(snakeCase);
    }
}
