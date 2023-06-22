using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Service;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("press any key to continue...");
            Console.ReadLine();
            ChannelFactory<IMessageService> channel = new ChannelFactory<IMessageService>(new NetTcpBinding(SecurityMode.None));
            IMessageService serverProxy = channel.CreateChannel(
                address: new EndpointAddress(
                    uri:"net.tcp://localhost:8000/MessageService"));
            Dolgozo[] res = serverProxy?.GetDolgozok();
            res?.ToList().ForEach(x => Console.WriteLine(x));

            Console.ReadKey();
        }
    }
}
