using grading_tab.domain.AggregateModels.PersonAggregate;

namespace grading_tab.infrastructure.EntityConfigurations
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person","dbo");
            builder.HasKey(x => x.Id);
        }
    }
}
