using grading_tab.domain.AggregateModels.SectionAggregate;

namespace grading_tab.infrastructure.EntityConfigurations;

public class SectionEntityTypeConfiguration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.ToTable("section", "dbo");
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Students).WithOne();
    }
}