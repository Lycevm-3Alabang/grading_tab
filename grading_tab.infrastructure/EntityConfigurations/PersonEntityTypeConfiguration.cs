using grading_tab.domain.AggregateModels.FacultyLoadAggregate;
using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace grading_tab.infrastructure.EntityConfigurations
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person","dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Number).IsRequired();
            builder.HasIndex(x => x.Number).IsUnique();

            builder.Property<Guid>("PersonId");
        }
    }

    public class SectionEntityTypeConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("section", "dbo");
            builder.HasKey(x => x.Id);
        }
    }

    public class SubjectEntityTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("subject", "dbo");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).IsRequired();
        }
    }

    public class SessionTypeEntityTypeConfiguration : IEntityTypeConfiguration<MeetingType>
    {
        public void Configure(EntityTypeBuilder<MeetingType> builder)
        {
            builder.ToTable("session_type", "dbo");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).IsRequired();
        }
    }

    public class FacultyLoadEntityTypeConfiguration : IEntityTypeConfiguration<SubjectLoad>
    {
        public void Configure(EntityTypeBuilder<SubjectLoad> builder)
        {
            builder.ToTable("faculty_load", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property("_sectionId").HasColumnName("SectionId");
            builder.HasOne(x => x.Section).WithMany().HasForeignKey("_sectionId");

            builder.Property("_subjectId").HasColumnName("SubjectId");
            builder.HasOne(x => x.Section).WithMany().HasForeignKey("_subjectId");

            builder.Property("_facultyId").HasColumnName("FacultyId");
            builder.HasOne(x => x.Section).WithMany().HasForeignKey("_facultyId");

            builder.Property("_onlineId").HasColumnName("OnlineSessionTypeId");
            builder.HasOne(x => x.Section).WithMany().HasForeignKey("_sectionId");
        }
    }
}
