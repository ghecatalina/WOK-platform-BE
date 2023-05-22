using System.Text.Json.Serialization;

namespace Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PayType
    {
        Cash = 1,
        Card = 2,
    }
}
