namespace BackendBatch7.Domain.Request.SearchParam
{
    public class BaseSearchParam
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchText { get; set; } = null;
        public BaseSearchParam()
        {

        }
        public BaseSearchParam(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize == 0 ? 10 : pageSize;
        }
    }
}
