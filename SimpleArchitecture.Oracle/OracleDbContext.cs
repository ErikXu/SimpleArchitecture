using System.Data.Entity;
using SimpleArchitecture.Domain.Entities;
using SimpleArchitecture.Domain.Entities.Mapping;

namespace SimpleArchitecture.Oracle
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext()
            : base("name=OracleDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("YOUR SCHEMA");

            modelBuilder.Configurations.Add(new TestAMap());
            modelBuilder.Configurations.Add(new TestBMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TestA> TestA { get; set; }
        public DbSet<TestB> TestB { get; set; }
    }
}