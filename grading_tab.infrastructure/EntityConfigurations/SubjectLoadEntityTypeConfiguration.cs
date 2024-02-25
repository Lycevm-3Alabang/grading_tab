using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
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
        builder.HasOne(x => x.Section)
            .WithMany()
            .HasForeignKey("_sectionId");
        
        builder.Property("_subjectId").HasColumnName("SubjectId");
        builder.HasOne(x => x.Subject)
            .WithMany()
            .HasForeignKey("_subjectId");
        
        builder.Property("_facultyId").HasColumnName("FacultyId");
        builder.HasOne(x => x.Faculty)
            .WithMany()
            .HasForeignKey("_facultyId");

        // builder.Property<Guid>("_sectionId")
        //     .UsePropertyAccessMode(PropertyAccessMode.Field)
        //     .HasColumnName("SectionId")
        //     .IsRequired();
        //
        // builder.HasOne<Section>()
        //     .WithMany()
        //     .HasForeignKey("_sectionId")
        //     .OnDelete(DeleteBehavior.NoAction);;
        
        // builder.Property<int>("_subjectId")
        //     .UsePropertyAccessMode(PropertyAccessMode.Field)
        //     .HasColumnName("SubjectId")
        //     .IsRequired();
        //
        // builder.HasOne<Subject>()
        //     .WithMany()
        //     .HasForeignKey("_subjectId")
        //     .OnDelete(DeleteBehavior.Restrict);
        
        // builder.Property<Guid>("_facultyId")
        //     .UsePropertyAccessMode(PropertyAccessMode.Field)
        //     .HasColumnName("FacultyId")
        //     .IsRequired();
        //
        // builder.HasOne<Person>()
        //     .WithMany()
        //     .HasForeignKey("_facultyId")
        //     .OnDelete(DeleteBehavior.Restrict);

   
       
        builder.HasMany(x => x.Meetings).WithOne();
    }
    
}