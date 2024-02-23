using grading_tab.domain.AggregateModels.AssessmentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace grading_tab.infrastructure.EntityConfigurations;

public class AssessmentResultEntityTypeConfiguration : IEntityTypeConfiguration<AssessmentResult>
{
    public void Configure(EntityTypeBuilder<AssessmentResult> builder)
    {
        builder.ToTable("assessment_result", "dbo");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Grade).IsRequired();
        builder.Property(x => x.TotalItems).IsRequired();
        builder.Property(x => x.Score).IsRequired();

        builder.Property("_typeId").HasColumnName("TypeId");
        builder.HasOne(x => x.Type)
            .WithMany()
            .HasForeignKey("_typeId");
            
        builder.Property("_studentId").HasColumnName("StudentId");
        builder.HasOne(x => x.Student)
            .WithMany()
            .HasForeignKey("_studentId");
            
        builder.Property("_termId").HasColumnName("TermId");
        builder.HasOne(x => x.Term)
            .WithMany()
            .HasForeignKey("_termId");
            
        builder.Property("_subjectId").HasColumnName("SubjectId");
        builder.HasOne(x => x.Subject)
            .WithMany()
            .HasForeignKey("_subjectId");
    }
        
       
}