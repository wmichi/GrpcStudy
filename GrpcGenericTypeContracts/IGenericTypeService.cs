using System.Threading.Tasks;
using ProtoBuf.Grpc.Configuration;

namespace GrpcGenericTypeContracts;

[Service]
public interface IGenericTypeService<T>
{
    [Operation]
    Task<SimpleGetResponse> SimpleGetAsync(SimpleGetRequest request);

    [Operation]
    Task<GenericTypeGetResponse<T>> GenericTypeGetAsync(GenericTypeGetRequest request);

}
