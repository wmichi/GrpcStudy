using GrpcGenericTypeContracts;
using GrpcGenericTypeServer.Services;
using ProtoBuf.Grpc.Reflection;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddCodeFirstGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<SimpleTypeService>();
    endpoints.MapGrpcService<GenericTypeService>();
});

// for checking the generated proto file
var generator = new SchemaGenerator();
var schema = generator.GetSchema<IGenericTypeService>();

Console.WriteLine(schema);

app.Run();
