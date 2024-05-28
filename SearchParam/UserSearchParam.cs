namespace BackendBatch7.SearchParam
{
    public class UserSearchParam : BaseSearchParam
    {
        public UserSearchParam(int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
        }

        public string? User { get; set; }
    }
}
