using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class StudentModels
{
    [JsonPropertyName("section_name")]
    [JsonRequired]
    public string? FirstName { get; init; }
    
    [JsonPropertyName("section_name")]
    [JsonRequired]
    public string? LastName { get; init; }
}