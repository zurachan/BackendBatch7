using BackendBatch7.Domain;

namespace BackendBatch7.Infrastructure
{
    public class UnitOfWork(DbFactory dbFactory) : IUnitOfWork
    {
        public bool Commit()
        {
            bool isSuccess = true;
            using (var dbContextTransaction = dbFactory.DbContext.Database.BeginTransaction())
            {
                try
                {
                    dbFactory.DbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    isSuccess = false;
                    dbContextTransaction.Rollback();
                }
            }
            return isSuccess;
        }

        public async Task<bool> CommitAsync()
        {
            bool isSuccess = true;
            using (var dbContextTransaction = dbFactory.DbContext.Database.BeginTransaction())
            {
                try
                {
                    await dbFactory.DbContext.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                }
                catch (Exception)
                {
                    isSuccess = false;
                    await dbContextTransaction.RollbackAsync();
                }
            }
            return isSuccess;
        }
    }
}
