using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Service;
using System.Diagnostics;
using System.Reflection;

namespace Server
{
    internal class Program
    {
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
        public class MessageService : IMessageService
        {
            private Dolgozo[] dolgozok;
            public MessageService() {
                    this.dolgozok = new Dolgozo[] {
                    new Dolgozo(1, "Nagy Károly", 2, "alma1.png"),
                    new Dolgozo(2, "Nagy Gizi", 1, "alma2.png"),
                    new Dolgozo(3, "Nagy Árpi", 3, "alma3.png")
                 };
            }
            public Dolgozo[] GetDolgozok()
            {
                MethodBase currentMethodName = new StackTrace().GetFrame(0).GetMethod();
                Console.WriteLine($"{currentMethodName.Name} called");
                return this.dolgozok;
            }
        }
        static void Main(string[] args)
        {
            Uri[] uri_addresses = new Uri[1];
            IMessageService service = new MessageService();
            uri_addresses[0] = new Uri("net.tcp://localhost:8000/MessageService");
            ServiceHost host = new ServiceHost(service, uri_addresses);
            var binding = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(typeof(IMessageService), binding, "");
            host.Opened += Host_Opened;
            host.Open();
            Console.ReadLine();
        }

        private static void Host_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("message service started");
        }
    }
}
