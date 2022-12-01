using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using GrpcGenericTypeContracts;
using ProtoBuf.Grpc.Client;

namespace GrpcGenericTypeClient;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:7065", new GrpcChannelOptions
        {
            HttpHandler = new GrpcWebHandler(new HttpClientHandler())
        });

        // SimpleTypeService
        var simpleClient = channel.CreateGrpcService<ISimpleTypeService>();
        var reply = await simpleClient.SimpleGetAsync(
            new SimpleTypeGetRequest { Message = "This is a Message for SimpleTypeService." });
        Console.WriteLine($"{reply.Result}");


        // GenericTypeForStringService
        var genericTypeClient = channel.CreateGrpcService<IGenericTypeService>();
        var simpleReply = await genericTypeClient.SimpleGetAsync(
            new SimpleGetRequest { Message = "This is a Message for GenericTypeService - SimpleGetAsync." });
        Console.WriteLine($"{simpleReply.Result}");
        
        var genericTypeForStringReply = await genericTypeClient.StringGetAsync(
            new GenericTypeGetRequest { Message = "This is a Message for GenericTypeService - GenericTypeGetAsync." });
        Console.WriteLine($"{genericTypeForStringReply.Result}");

        var genericTypeForModelReply = await genericTypeClient.ModelGetAsync(
            new GenericTypeGetRequest { Message = "This is a Message for GenericTypeService - GenericTypeGetAsync." });
        Console.WriteLine($"Result Id: {genericTypeForModelReply.Result.Id} / {genericTypeForModelReply.Result.ResultMessage}");


        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}