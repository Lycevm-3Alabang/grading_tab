using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace grading_tab.infrastructure.EntityConfigurations;

public class MeetingTypeEntityTypeConfiguration : IEntityTypeConfiguration<MeetingType>
{
    public void Configure(EntityTypeBuilder<MeetingType> builder)
    {
        builder.ToTable("meeting_type", "dbo");
        builder.HasKey(x => x.Id);
        // builder.Property(o => o.Id)
        //     .UseHiLo("meeting_type_seq", "dbo");
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Name).IsRequired();
        builder.HasData(MeetingType.Seed());
    }
}