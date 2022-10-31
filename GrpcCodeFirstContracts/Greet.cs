using System.Runtime.Serialization;
using System.ServiceModel;
using ProtoBuf;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace GrpcCodeFirstContracts;

[ProtoContract]
public class HelloReply
{
    [ProtoMember(1)]
    public string Message { get; set; }
}

[ProtoContract]
public class HelloRequest
{
    [ProtoMember(1)]
    public string Name { get; set; }
}

[Service]
public interface IGreeterService
{
    [Operation]
    Task<HelloReply> SayHelloAsync(HelloRequest request,
        CallContext context = default);
}