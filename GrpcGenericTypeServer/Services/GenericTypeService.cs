using GrpcGenericTypeContracts;

namespace GrpcGenericTypeServer.Services;

public class GenericTypeForStringService : IGenericTypeService<string>
{
    private readonly ILogger<GenericTypeForStringService> _logger;

    public GenericTypeForStringService(ILogger<GenericTypeForStringService> logger)
    {
        _logger = logger;
    }

    public async Task<SimpleGetResponse> SimpleGetAsync(SimpleGetRequest request)
    {
        _logger.LogInformation("Execute SimpleGetAsync of GenericTypeForStringService");

        var result = $"Received the message '{request.Message}'  from the client";
        return new SimpleGetResponse
        {
            Result = result
        };
    }

    public async Task<GenericTypeGetResponse<string>> GenericTypeGetAsync(GenericTypeGetRequest request)
    {
        _logger.LogInformation("Execute GenericTypeGetAsync of GenericTypeForStringService");

        var result = $"Received the message '{request.Message}'  from the client";
        return new GenericTypeGetResponse<string>
        {
            Result = result
        };

    }
}

public class GenericTypeForModelService : IGenericTypeService<ModelForGenericType>
{
    private readonly ILogger<GenericTypeForModelService> _logger;

    public GenericTypeForModelService(ILogger<GenericTypeForModelService> logger)
    {
        _logger = logger;
    }

    public async Task<SimpleGetResponse> SimpleGetAsync(SimpleGetRequest request)
    {
        _logger.LogInformation("Execute SimpleGetAsync of GenericTypeForStringService");

        var result = $"Received the message '{request.Message}'  from the client";
        return new SimpleGetResponse
        {
            Result = result
        };
    }

    public async Task<GenericTypeGetResponse<ModelForGenericType>> GenericTypeGetAsync(GenericTypeGetRequest request)
    {
        _logger.LogInformation("Execute GenericTypeGetAsync of GenericTypeForModelService");

        var result = $"Received the message '{request.Message}'  from the client";
        return new GenericTypeGetResponse<ModelForGenericType>
        {
            Result = new ModelForGenericType
            {
                Id = 20221130,
                ResultMessage = result
            }
        };

    }
}
