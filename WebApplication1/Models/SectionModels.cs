using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class AddSectionModel
{
    [JsonPropertyName("section_name")]
    [JsonRequired]
    public string? Name { get; init; }
}