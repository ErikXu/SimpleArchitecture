using System.Data.Entity;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using SimpleArchitecture.Domain.Entities;
using SimpleArchitecture.Domain.Repositories;

namespace SimpleArchitecture.Oracle.Repositories
{
    public class TestARepository : GenericRepository<TestA>, ITestARepository
    {
        public TestARepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public int Update(int id, string firstName, string lastName)
        {
            const string sql = @"update test_a 
                                 set first_name = :first_name,
                                     last_name = :last_name
                                     where id = :id";

            return DbContext.Database.ExecuteSqlCommand(sql, FluentParameter.In("first_name", OracleDbType.Varchar2).SetSize(50).SetValue(firstName),
                                                             FluentParameter.In("last_name", OracleDbType.Varchar2).SetSize(50).SetValue(lastName),
                                                             FluentParameter.In("id", OracleDbType.Int32).SetValue(id)); 
        }

        public int Delete(int id)
        {
            return DbContext.Database.ExecuteSqlCommand("delete test_a where id = :id", FluentParameter.In("id", OracleDbType.Int32).SetValue(id)); 
        }
    }
}