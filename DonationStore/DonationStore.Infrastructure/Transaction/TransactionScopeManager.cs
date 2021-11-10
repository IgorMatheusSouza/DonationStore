using DonationStore.Infrastructure.Constants;
using System;
using System.Transactions;

namespace DonationStore.Infrastructure.Transaction
{
    public class TransactionScopeManager : ITransactionScopeManager
    {
        private TransactionScope TransactionScope;

        public void BeginTransaction(int timeout = SystemConstantValues.DefaultTimeOnScopeTransactionInMinutes)
        {
            TransactionScope = new TransactionScope
            (
                TransactionScopeOption.Required,
                new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted,
                    Timeout = TimeSpan.FromMinutes(timeout)
                },
                TransactionScopeAsyncFlowOption.Enabled
            );
        }

        public void Commit()
        {
            TransactionScope.Complete();
        }

        public void Rollback()
        {
            TransactionScope?.Dispose();
        }
    }
}
