namespace SimpleArchitecture.Domain.Services
{
    public interface ITestService
    {
        void Create(int id, string firstName, string lastName, string content);

        void Update(int id, string content);

        void Update(int id, string firstName, string lastName, string content);

        void Delete(int id);
    }
}