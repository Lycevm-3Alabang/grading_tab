using Dapper;
using grading_tab.application.Application.Common.Interfaces;

namespace grading_tab.application.Application.Features.Section.Queries;

public class SectionQueries(IDbConnectionFactory dbConnectionFactory) : ISectionQueries
{
    public async Task<IEnumerable<SectionResult>> GetSectionsAsync()
    {
        const string query = """
                             select SectionId, 
                                    name [Section], 
                                    student.Id [StudentId], 
                                    Number [StudentNumber], 
                                    Course, 
                                    PersonId [PersonId],
                                    FirstName,
                                    LastName, 
                                    MiddleName,
                                    NameSuffix
                             from dbo.section
                                 inner join dbo.student on section.Id = student.SectionId
                                 inner join dbo.person on person.Id = student.PersonId
                             """;

        await using var connection = dbConnectionFactory.CreateConnection();
        await connection.OpenAsync();
        var result = await connection.QueryAsync<SectionResult>(query);
        return result;
    }

    public Task<IEnumerable<Student>> GetStudentsAsync(Guid sectionId)
    {
        throw new NotImplementedException();
    }
}