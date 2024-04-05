namespace grading_tab.application.Application.Features.Section.Queries;

public interface ISectionQueries
{
    Task<IEnumerable<SectionResult>> GetSectionsAsync();
    Task<IEnumerable<Student>> GetStudentsAsync(Guid sectionId);
}

public record SectionResult(string Name, int StudentCount);

public record Student
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? MiddleName { get; init; }
    public string? NameSuffix { get; init; }
    public string? Section { get; init; }
    public string? StudentNumber { get; init; }
    public string? Course { get; init; }
    public Guid SectionId { get; init; }
    public Guid StudentId { get; init; }
    public Guid PersonId { get; init; }
}