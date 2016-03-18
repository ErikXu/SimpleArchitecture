using SimpleArchitecture.Domain.Entities;

namespace SimpleArchitecture.Domain.Repositories
{
    public interface ITestBRepository : IGenericRepository<TestB>
    {
        int Update(int id, string content);
        int Delete(int id);
    }
}