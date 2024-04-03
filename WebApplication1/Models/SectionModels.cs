using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public record AddSectionModel
{
    [JsonPropertyName("section_name")]
    [JsonRequired]
    public string? Name { get; init; }
}