using grading_tab.application.Application.Features.Section.Commands.AddSection;
using grading_tab.application.Application.Features.Section.Commands.AddStudent;
using WebApplication1.Models;

namespace WebApplication1.Extensions;

public static class SectionModelExtensions
{
    public static AddSectionCommand ToCommand(this AddSectionModel model) => new AddSectionCommand(model.Name);
    
    public static AddStudentCommand ToCommand(this AddStudentModel model, Guid? sectionId) => new AddStudentCommand()
    {
        Course = model.Course,
        SectionId = sectionId,
        FirstName = model.FirstName,
        LastName = model.LastName,
        Middlename = model.MiddleName,
        Number = model.Number,
        NameSuffix = model.NameSuffix
    };
}