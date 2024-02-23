using System.Collections.Immutable;
using grading_tab.domain.AggregateModels.SectionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace grading_tab.infrastructure.EntityConfigurations;

public class SubjectLoadEntityTypeConfiguration : IEntityTypeConfiguration<SubjectLoad>
{
    public void Configure(EntityTypeBuilder<SubjectLoad> builder)
    {
        builder.ToTable("subject_load", "dbo");
        builder.HasKey(x => x.Id);

        builder.Property("_sectionId").HasColumnName("SectionId");
        builder.HasOne(x => x.Section).WithMany().HasForeignKey("_sectionId").OnDelete(DeleteBehavior.NoAction);

        builder.Property("_subjectId").HasColumnName("SubjectId");
        builder.HasOne(x => x.Section).WithMany().HasForeignKey("_subjectId").OnDelete(DeleteBehavior.NoAction);

        builder.Property("_facultyId").HasColumnName("FacultyId");
        builder.HasOne(x => x.Section).WithMany().HasForeignKey("_facultyId").OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Meetings).WithOne();
    }
    
}