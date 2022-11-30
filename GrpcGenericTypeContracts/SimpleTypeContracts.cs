using ProtoBuf;

namespace GrpcGenericTypeContracts;

[ProtoContract]
public class SimpleTypeGetRequest
{
    [ProtoMember(1)]
    public string Message { get; set; }
}

[ProtoContract]
public class SimpleTypeGetResponse
{
    [ProtoMember(1)]
    public string Result { get; set; }
}
