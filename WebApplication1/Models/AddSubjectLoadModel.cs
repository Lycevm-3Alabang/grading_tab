using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public record AddSubjectLoadModel
{
    [JsonPropertyName("faculty_id")]
    [JsonRequired]
    public Guid? FacultyId { get; init; }
    [JsonPropertyName("section_id")]
    [JsonRequired]
    public Guid? SectionId { get; init; }
    [JsonPropertyName("subject_id")]
    [JsonRequired]
    public int? SubjectId { get; init; }
}