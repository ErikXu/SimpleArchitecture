using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SimpleArchitecture.Domain.Entities.Mapping
{
    public class TestBMap : EntityTypeConfiguration<TestB>
    {
        public TestBMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Content)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
			ToTable("TEST_B");
            Property(t => t.Id).HasColumnName("ID");
            Property(t => t.Content).HasColumnName("CONTENT");
        }
    }
}

