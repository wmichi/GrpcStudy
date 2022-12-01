using GrpcGenericTypeContracts;

namespace GrpcGenericTypeServer.Services;

public class GenericTypeService : IGenericTypeService
{
    private readonly ILogger<GenericTypeService> _logger;

    public GenericTypeService(ILogger<GenericTypeService> logger)
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

    public async Task<GenericTypeGetResponse<string>> StringGetAsync(GenericTypeGetRequest request)
    {
        _logger.LogInformation("Execute GenericTypeGetAsync of GenericTypeForStringService");

        var result = $"Received the message '{request.Message}'  from the client";
        return new GenericTypeGetResponse<string>()
        {
            Result = result
        };

    }

    public async Task<GenericTypeGetResponse<ModelForGenericType>> ModelGetAsync(GenericTypeGetRequest request)
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


