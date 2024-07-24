namespace BackendBatch7.API.SearchParam
{
    public class UserSearchParam : BaseSearchParam
    {
        public UserSearchParam()
        {
        }

        public UserSearchParam(int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
        }

        public string? User { get; set; }
    }
}
