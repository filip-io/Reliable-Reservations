//using System.Text.Json.Serialization;
//using System.Text.Json;

//namespace Reliable_Reservations.Helpers
//{
//    public class JsonDateConverter : JsonConverter<DateTime>
//    {
//        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//        {
//            return DateTime.Parse(reader.GetString());
//        }

//        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
//        {
//            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss")); // Adjust format as needed
//        }
//    }
//}
