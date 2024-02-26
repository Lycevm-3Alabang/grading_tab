using grading_tab.domain.AggregateModels.AssessmentAggregate;

namespace grading_tab.infrastructure.EntityConfigurations;

public class TermEntityTypeConfiguration : IEntityTypeConfiguration<Term>
{
    public void Configure(EntityTypeBuilder<Term> builder)
    {
        builder.ToTable("term", "dbo");
        builder.HasKey(x => x.Id);
        builder.HasData(Term.Seed());

    }
}