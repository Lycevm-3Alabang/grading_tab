using grading_tab.domain.AggregateModels.PersonAggregate;
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
            builder.Property<Guid>("SectionId");
           
        }
    }
}
