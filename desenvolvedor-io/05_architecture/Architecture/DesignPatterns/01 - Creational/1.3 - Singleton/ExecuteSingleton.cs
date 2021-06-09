using System;

namespace DesignPatterns.Singleton
{
    public class ExecuteSingleton
    {
        public static void Execute()
        {
            var loadBalancer1 = LoadBalancer.GetLoadBalancer();
            var loadBalancer2 = LoadBalancer.GetLoadBalancer();
            var loadBalancer3 = LoadBalancer.GetLoadBalancer();
            var loadBalancer4 = LoadBalancer.GetLoadBalancer();

            if (loadBalancer1 == loadBalancer2 &&
                loadBalancer2 == loadBalancer3 &&
                loadBalancer3 == loadBalancer4)
            {
                Console.WriteLine("Same instance\n");
            }

            var loadBalancer = LoadBalancer.GetLoadBalancer();

            for (var i = 0; i < 15; i++)
            {
                Console.WriteLine($"Sending request to: {loadBalancer.NextServer.Name}");
            }
        }
    }
}
