using grading_tab.domain.AggregateModels.SectionAggregate;

namespace grading_tab.infrastructure.EntityConfigurations;

public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("student","dbo");
        builder.HasKey(x => x.Id);
            
        builder.Property("_personId").HasColumnName("PersonId");
        builder.HasOne(x => x.Person)
            .WithMany()
            .HasForeignKey("_personId");
    }
}