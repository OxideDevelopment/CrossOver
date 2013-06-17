using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossOver.MethodResult
{
    class Computer
    {
        string hostName;
        public string HostName
        {
            get { return hostName; }
        }

        string ipAddress;
        public string IpAddress
        {
            get { return ipAddress; }
        }

        public Computer(string hostname, string ipaddress)
        {
            hostName = hostname;
            ipAddress = ipaddress;
        }
    }
}
