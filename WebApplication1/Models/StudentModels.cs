using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class AddStudentModel
{
    [JsonPropertyName("first_name")]
    [JsonRequired]
    public string? FirstName { get; init; }
    
    [JsonPropertyName("last_name")]
    [JsonRequired]
    public string? LastName { get; init; }
    
    [JsonPropertyName("middle_name")]
    [JsonRequired]
    public string? MiddleName { get; init; }
    
    [JsonPropertyName("name_suffix")]
    [JsonRequired]
    public string? NameSuffix { get; init; }
    
    [JsonPropertyName("student_number")]
    [JsonRequired]
    public string? Number { get; init; }
    
    [JsonPropertyName("course")]
    [JsonRequired]
    public string? Course { get; init; }
}