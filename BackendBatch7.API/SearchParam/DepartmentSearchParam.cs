namespace BackendBatch7.API.SearchParam
{
    public class DepartmentSearchParam : BaseSearchParam
    {
        public DepartmentSearchParam()
        {
        }

        public DepartmentSearchParam(int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
        }

        public string? Department { get; set; }
    }
}
