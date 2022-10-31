using Grpc.Core;
using GrpcCodeFirstServer;
using GrpcCodeFirstContracts;
using ProtoBuf.Grpc;

namespace GrpcCodeFirstServer.Services
{
    public class GreeterService : IGreeterService
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public Task<HelloReply> SayHelloAsync(HelloRequest request, CallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello World to " + request.Name
            });
        }
    }
}