namespace BackendBatch7.Infrastructure.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
        Task<bool> ExecuteInTransactionAsync(Func<Task> action);
        Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> action);
    }
}
