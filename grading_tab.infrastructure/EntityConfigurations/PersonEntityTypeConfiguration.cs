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
        }
    }
    
    public class StudentEntityTyeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("student","dbo");
            builder.HasKey(x => x.Id);
            
            builder.Property<Guid>("_personId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("PersonId")
                .IsRequired();

            builder.HasOne<Person>()
                .WithMany()
                .HasForeignKey("_personId")
                .OnDelete(DeleteBehavior.Restrict);;
        }
    }
}
