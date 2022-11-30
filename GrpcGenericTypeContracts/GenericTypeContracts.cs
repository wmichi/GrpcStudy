using ProtoBuf;

namespace GrpcGenericTypeContracts;

[ProtoContract]
public class SimpleGetRequest
{
    [ProtoMember(1)]
    public string Message { get; set; }
}

[ProtoContract]
public class SimpleGetResponse
{
    [ProtoMember(1)]
    public string Result { get; set; }
}

[ProtoContract]
public class GenericTypeGetRequest
{
    [ProtoMember(1)]
    public string Message { get; set; }
}

[ProtoContract]
public class GenericTypeGetResponse<T>
{
    [ProtoMember(1)]
    public T Result { get; set; }
}

[ProtoContract]
public class ModelForGenericType
{
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    public string ResultMessage { get; set; }

}