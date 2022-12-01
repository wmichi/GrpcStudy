using System.Threading.Tasks;
using ProtoBuf.Grpc.Configuration;

namespace GrpcGenericTypeContracts;

[Service]
public interface IGenericTypeService
{
    [Operation]
    Task<SimpleGetResponse> SimpleGetAsync(SimpleGetRequest request);

    [Operation]
    Task<GenericTypeGetResponse<string>> StringGetAsync(GenericTypeGetRequest request);

    [Operation]
    Task<GenericTypeGetResponse<ModelForGenericType>> ModelGetAsync(GenericTypeGetRequest request);
}
