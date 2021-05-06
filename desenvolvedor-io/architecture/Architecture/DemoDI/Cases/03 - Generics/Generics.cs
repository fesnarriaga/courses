namespace DemoDI.Cases
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public void Add(T obj)
        {
            // Do something
        }
    }

    public interface IGenericRepository<T> where T : class
    {
        void Add(T obj);
    }
}
