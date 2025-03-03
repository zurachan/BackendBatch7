namespace BackendBatch7.Domain.Request.SearchParam
{
    public class DepartmentSearchParam : BaseSearchParam
    {
        public DepartmentSearchParam()
        {
        }

        public DepartmentSearchParam(int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
        }
    }
}
