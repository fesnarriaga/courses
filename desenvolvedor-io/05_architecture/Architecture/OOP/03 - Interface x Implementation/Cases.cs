namespace OOP
{
    public interface IRepository
    {
        void Add();
    }

    public class Repository : IRepository
    {
        public void Add()
        {
            // Do something
        }
    }

    public class RepositoryFake : IRepository
    {
        public void Add()
        {
            // Do something
        }
    }

    public class UsesImplementation
    {
        public void Process()
        {
            var repository = new Repository();

            repository.Add();
        }
    }

    public class UsesAbstraction
    {
        private readonly IRepository _repository;

        public UsesAbstraction(IRepository repository)
        {
            _repository = repository;
        }

        public void Process()
        {
            _repository.Add();
        }
    }

    public class TestInterfaceImplementation
    {
        public TestInterfaceImplementation()
        {
            var repositoryImplementation = new UsesImplementation();
            repositoryImplementation.Process();

            var repositoryAbstraction = new UsesAbstraction(new Repository());
            repositoryAbstraction.Process();

            var repositoryFakeAbstraction = new UsesAbstraction(new RepositoryFake());
            repositoryFakeAbstraction.Process();
        }
    }
}
