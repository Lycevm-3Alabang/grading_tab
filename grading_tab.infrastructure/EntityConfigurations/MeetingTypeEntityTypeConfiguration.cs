using grading_tab.domain.AggregateModels.FacultyLoadAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace grading_tab.infrastructure.EntityConfigurations;

public class MeetingTypeEntityTypeConfiguration : IEntityTypeConfiguration<MeetingType>
{
    public void Configure(EntityTypeBuilder<MeetingType> builder)
    {
        builder.ToTable("meeting_type", "dbo");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Name).IsRequired();
    }
}