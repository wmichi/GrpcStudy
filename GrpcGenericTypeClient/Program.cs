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
        var genericTypeForStringClient = channel.CreateGrpcService<IGenericTypeService<string>>();
        var simpleReply = await genericTypeForStringClient.SimpleGetAsync(
            new SimpleGetRequest { Message = "This is a Message for GenericTypeService - SimpleGetAsync." });
        Console.WriteLine($"{simpleReply.Result}");
        
        var genericTypeForStringReply = await genericTypeForStringClient.GenericTypeGetAsync(
            new GenericTypeGetRequest { Message = "This is a Message for GenericTypeService - GenericTypeGetAsync." });
        Console.WriteLine($"{genericTypeForStringReply.Result}");


        // GenericTypeForModelService
        var genericTypeForModelClient = channel.CreateGrpcService<IGenericTypeService<ModelForGenericType>>();
        var genericTypeForModelReply = await genericTypeForModelClient.GenericTypeGetAsync(
            new GenericTypeGetRequest { Message = "This is a Message for GenericTypeService - GenericTypeGetAsync." });
        Console.WriteLine($"Result Id: {genericTypeForModelReply.Result.Id} / {genericTypeForModelReply.Result.ResultMessage}");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}