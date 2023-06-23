using Grpc.Net.Client;
using Server;
using System.Configuration;

string? url = ConfigurationManager.AppSettings["url"];
if(url == null)
{
    Console.WriteLine("Server unreachable: field 'url' is empty in \'App.config\'...");
    return;
}
GrpcChannel channel = GrpcChannel.ForAddress(url);
/* the usage of Greeter Service:
    Greeter.GreeterClient client = new Greeter.GreeterClient(channel);
    HelloReply reply = await client.SayHelloAsync(new HelloRequest() { Name = "Bence" });
    Console.WriteLine(reply.Message);
*/

Dolgozo.DolgozoClient client = new Dolgozo.DolgozoClient(channel);
Response resp = client.AddDolgozo(new DolgozoModel { Nev = "Alma Alma", FotoNev = "alma.png", ReszlegId = 2 });
if(resp.Code == 500)
{
    Console.WriteLine("Error while calling AddDolgozoAsync...");
    return;
}
Console.WriteLine(resp.Code);

DolgozoModel found = client.GetDolgozo(new DolgozoID() { Id = 0 });
Console.WriteLine($"Dolgozo found: {found}");
try
{
    found = client.GetDolgozo(new DolgozoID() { Id = 1 });
}catch(InvalidDataException e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine(found);
Console.WriteLine("Press Enter to exit the program!");
Console.ReadLine();