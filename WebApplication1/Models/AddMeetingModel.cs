using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public record AddMeetingModel
{
    [JsonPropertyName("meeting_type_id")]
    [JsonRequired]
    public int MeetingTypeId { get; init; }
    [JsonPropertyName("start_time")]
    [JsonRequired]
    public int StartTime { get; init; }
    [JsonPropertyName("end_time")]
    [JsonRequired]
    public int EndTime { get; init; }
    [JsonPropertyName("day")]
    [JsonRequired]
    public DayOfWeek Day { get; init; }
}