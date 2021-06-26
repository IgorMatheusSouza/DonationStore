using DonationStore.Infrastructure.Constants;

namespace DonationStore.Infrastructure.Transaction
{
    public interface ITransactionScopeManager
    {
        void BeginTransaction(int timeout = SystemConstantValues.DefaultTimeOnScopeTransactionInMinutes);
        void Commit();
        void Rollback();
    }
}
