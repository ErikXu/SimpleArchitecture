using SimpleArchitecture.Domain.Entities;

namespace SimpleArchitecture.Domain.Repositories
{
    public interface ITestARepository : IGenericRepository<TestA>
    {
        int Update(int id, string firstName, string lastName);
        int Delete(int id);
    }
}