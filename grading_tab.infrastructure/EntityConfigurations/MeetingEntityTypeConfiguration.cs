using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace grading_tab.infrastructure.EntityConfigurations;

public class MeetingEntityTypeConfiguration : IEntityTypeConfiguration<Meeting>
{
    public void Configure(EntityTypeBuilder<Meeting> builder)
    {
        builder.ToTable("meeting", "dbo");
        builder.HasKey(x => x.Id);

        builder.Property("_typeId").HasColumnName("TypeId");
        builder.HasOne(x => x.Type).WithMany().HasForeignKey("_typeId");

            
    }
}