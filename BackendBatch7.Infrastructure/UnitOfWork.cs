using BackendBatch7.Domain;

namespace BackendBatch7.Infrastructure
{
    public class UnitOfWork(DbFactory dbFactory) : IUnitOfWork
    {
        public async Task<bool> CommitAsync()
        {
            bool returnValue = true;
            using (var dbContextTransaction = dbFactory.DbContext.Database.BeginTransaction())
            {
                try
                {
                    await dbFactory.DbContext.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                }
                catch (Exception)
                {
                    returnValue = false;
                    await dbContextTransaction.RollbackAsync();
                }
            }
            return returnValue;
        }
    }
}
