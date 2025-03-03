namespace BackendBatch7.Domain.Response.Base;

public class Response<T>
{
    public Response()
    {
    }
    public Response(T data)
    {
        Success = true;
        Message = string.Empty;
        Data = data;
    }
    public T? Data { get; set; }
    public bool Success { get; set; } = false;
    public string Message { get; set; } = string.Empty;
}
