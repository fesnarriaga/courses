using System;

namespace OOP
{
    public class CustomerInheritance : Person
    {
        public string Document { get; set; }
    }

    public class CustomerComposition
    {
        public Person Person { get; set; }
        public string Document { get; set; }
    }

    public class TestsInheritanceComposition
    {
        public TestsInheritanceComposition()
        {
            var customerInheritance = new CustomerInheritance
            {
                Name = "John Doe",
                BirthDate = DateTime.Now,
                Document = "12345678901"
            };

            var customerComposition = new CustomerComposition
            {
                Person = new Person
                {
                    Name = "John Doe",
                    BirthDate = DateTime.Now
                },
                Document = "12345678901"
            };

            var nameInheritance = customerInheritance.Name;
            var nameComposition = customerComposition.Person.Name;
        }
    }

    public interface IRepository<T>
    {
        void Add(T entity);

        void Remove(T entity);
    }

    public interface IPersonRepository
    {
        void Add(Person person);
    }

    public class Repository<T> : IRepository<T>
    {
        public void Add(T entity)
        {
            // Do something
        }

        public void Remove(T entity)
        {
            // Do something
        }
    }

    public class RepositoryInheritance : Repository<Person>, IPersonRepository { }

    public class RepositoryComposition : IPersonRepository
    {
        private readonly IRepository<Person> _repository;

        public RepositoryComposition(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public void Add(Person person)
        {
            _repository.Add(person);
        }
    }

    public class TestsInheritanceCompositionRepositories
    {
        public TestsInheritanceCompositionRepositories()
        {
            var inheritanceRepository = new RepositoryInheritance();
            inheritanceRepository.Add(new Person());
            inheritanceRepository.Remove(new Person());

            var compositionRepository = new RepositoryComposition(new Repository<Person>());
            compositionRepository.Add(new Person());
        }
    }
}
