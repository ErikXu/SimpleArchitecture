using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SimpleArchitecture.Domain.Entities.Mapping
{
    public class TestAMap : EntityTypeConfiguration<TestA>
    {
        public TestAMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
			ToTable("TEST_A");
            Property(t => t.Id).HasColumnName("ID");
            Property(t => t.FirstName).HasColumnName("FIRST_NAME");
            Property(t => t.LastName).HasColumnName("LAST_NAME");
        }
    }
}

