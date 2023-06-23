using Grpc.Net.Client;
using Server;
using System.Configuration;

string? url = ConfigurationManager.AppSettings["url"];
if(url == null)
{
    Console.WriteLine("ejnyebejnye");
    return;
}
GrpcChannel channel = GrpcChannel.ForAddress(url);
/* the usage of Greeter Service:
    Greeter.GreeterClient client = new Greeter.GreeterClient(channel);
    HelloReply reply = await client.SayHelloAsync(new HelloRequest() { Name = "Bence" });
    Console.WriteLine(reply.Message);
*/



Console.WriteLine("Press Enter to exit the program!");
Console.ReadLine();