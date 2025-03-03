namespace BackendBatch7.Domain.Response.Base;

public class PaginatedResponse<T> : Response<T>
{
    public PaginatedResponse()
    {
    }
    public PaginatedResponse(T? data, Paging? paging)
    {
        Data = data;
        Paging = paging;
        Message = string.Empty;
        Success = true;
    }
    public Paging? Paging { get; set; }
}
