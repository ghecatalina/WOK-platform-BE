using System.Text.Json.Serialization;

namespace Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageType
    {
        CallWaiter = 1,
        GetCheck = 2,
    }
}
