namespace BackendBatch7.Domain
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
