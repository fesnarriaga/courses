using System;
using System.Collections.Generic;

namespace DesignPatterns.Singleton
{
    internal sealed class LoadBalancer
    {
        private static readonly LoadBalancer Instance = new LoadBalancer();

        private readonly List<Server> _servers;
        private readonly Random _random = new Random();

        public Server NextServer
        {
            get
            {
                var random = _random.Next(_servers.Count);
                return _servers[random];
            }
        }

        private LoadBalancer()
        {
            _servers = new List<Server>
            {
                new Server{ Id = Guid.NewGuid(), Name = "Server1", Ip = "120.14.220.18" },
                new Server{ Id = Guid.NewGuid(), Name = "Server2", Ip = "120.14.220.19" },
                new Server{ Id = Guid.NewGuid(), Name = "Server3", Ip = "120.14.220.20" },
                new Server{ Id = Guid.NewGuid(), Name = "Server4", Ip = "120.14.220.21" },
                new Server{ Id = Guid.NewGuid(), Name = "Server5", Ip = "120.14.220.22" },
            };
        }

        public static LoadBalancer GetLoadBalancer()
        {
            return Instance;
        }
    }
}
