namespace DemoDI.Cases
{
    public class ServiceA : IService
    {
        public string Result()
        {
            return "A";
        }
    }

    public class ServiceB : IService
    {
        public string Result()
        {
            return "B";
        }
    }

    public class ServiceC : IService
    {
        public string Result()
        {
            return "C";
        }
    }

    public interface IService
    {
        string Result();
    }
}
