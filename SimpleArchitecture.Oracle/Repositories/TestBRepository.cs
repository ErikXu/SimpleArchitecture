using System.Data.Entity;
using Oracle.ManagedDataAccess.Client;
using SimpleArchitecture.Domain.Entities;
using SimpleArchitecture.Domain.Repositories;

namespace SimpleArchitecture.Oracle.Repositories
{
    public class TestBRepository : GenericRepository<TestB>, ITestBRepository
    {
        public TestBRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public int Update(int id, string content)
        {
            const string sql = @"update test_b set content = :content where id = :id";

            return DbContext.Database.ExecuteSqlCommand(sql, FluentParameter.In("content", OracleDbType.Varchar2).SetSize(200).SetValue(content),
                                                             FluentParameter.In("id", OracleDbType.Int32).SetValue(id)); 
        }

        public int Delete(int id)
        {
            return DbContext.Database.ExecuteSqlCommand("delete test_b where id = :id", FluentParameter.In("id", OracleDbType.Int32).SetValue(id)); 
        }
    }
}