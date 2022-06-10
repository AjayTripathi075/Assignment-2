using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Assignment_2.Validation.DateConverter
{
    public class DateConverter : JsonConverter<DateTime>
    {
        private string FormatDate = "yyyy-MM-ddTHH:mm:ss.fffZ";
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), FormatDate, CultureInfo.InvariantCulture);

        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(FormatDate));
        }
    }
}
