using System.Text.Json.Serialization;

namespace Platform.Core.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ItemType
    {
        Lecture, Event
    }
}
