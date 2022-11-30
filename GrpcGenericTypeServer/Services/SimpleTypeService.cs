using GrpcGenericTypeContracts;

namespace GrpcGenericTypeServer.Services;

public class SimpleTypeService : ISimpleTypeService
{
    private readonly ILogger<SimpleTypeService> _logger;
    
    public SimpleTypeService(ILogger<SimpleTypeService> logger)
    {
        _logger = logger;
    }

    public async Task<SimpleTypeGetResponse> SimpleGetAsync(SimpleTypeGetRequest request)
    {
        var result = $"Received the message '{request.Message}'  from the client";
        return new SimpleTypeGetResponse
        {
            Result = result
        };
    }
}
