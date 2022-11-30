using ProtoBuf.Grpc.Configuration;
using System.Threading.Tasks;

namespace GrpcGenericTypeContracts;

[Service]
public interface ISimpleTypeService
{
    [Operation]
    Task<SimpleTypeGetResponse> SimpleGetAsync(SimpleTypeGetRequest request);
}

