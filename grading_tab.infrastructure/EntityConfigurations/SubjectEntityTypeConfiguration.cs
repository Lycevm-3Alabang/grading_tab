using grading_tab.domain.AggregateModels.SubjectLoadAggregate;

namespace grading_tab.infrastructure.EntityConfigurations;

public class SubjectEntityTypeConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("subject", "dbo");
        builder.HasKey(x => x.Id);
        // builder.Property(o => o.Id)
        //     .UseHiLo("subject_seq", "dbo");
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Name).IsRequired();
        builder.HasData(Subject.Seed());
    }
}