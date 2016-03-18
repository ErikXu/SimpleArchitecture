using SimpleArchitecture.Domain.Entities;
using SimpleArchitecture.Domain.Repositories;

namespace SimpleArchitecture.Domain.Services.Impl
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestARepository _testARepository;
        private readonly ITestBRepository _testBRepository;

        public TestService(IUnitOfWork unitOfWork, ITestARepository testARepository, ITestBRepository testBRepository)
        {
            _unitOfWork = unitOfWork;
            _testARepository = testARepository;
            _testBRepository = testBRepository;
        }

        public void Create(int id, string firstName, string lastName, string content)
        {
            var testA = new TestA
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };

            var testB = new TestB
            {
                Id = id,
                Content = content
            };

            using (_unitOfWork.BeginTransaction())
            {
                try
                {
                    _testARepository.Insert(testA);
                    _testBRepository.Insert(testB);
                    _unitOfWork.SaveChanges();
                    _unitOfWork.Commit();
                }
                catch
                {
                    _unitOfWork.Rollback();
                    throw;
                }
            }
        }

        public void Update(int id, string content)
        {
            var testB = _testBRepository.GetById(id);
            testB.Content = content;
            _testBRepository.Update(testB);
            _unitOfWork.SaveChanges();
        }

        public void Update(int id, string firstName, string lastName, string content)
        {
            using (_unitOfWork.BeginTransaction())
            {
                try
                {
                    _testARepository.Update(id, firstName, lastName);
                    _testBRepository.Update(id, content);
                    _unitOfWork.SaveChanges();
                    _unitOfWork.Commit();
                }
                catch
                {
                    _unitOfWork.Rollback();
                    throw;
                }
            }
        }

        public void Delete(int id)
        {
            using (_unitOfWork.BeginTransaction())
            {
                try
                {
                    _testARepository.Delete(id);
                    _testBRepository.Delete(id);
                    _unitOfWork.SaveChanges();
                    _unitOfWork.Commit();
                }
                catch
                {
                    _unitOfWork.Rollback();
                    throw;
                }
            }
        }
    }
}