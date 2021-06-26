using DonationStore.Infrastructure.Transaction;
using MediatR;

namespace DonationStore.Application.Services
{
    public abstract class BaseService
    {
        protected ITransactionScopeManager TransactionScopeManager;
        protected IMediator Mediator { get; private set; }

        protected BaseService(IMediator mediator, ITransactionScopeManager transactionScopeManager)
        {
            this.Mediator = mediator;
            this.TransactionScopeManager = transactionScopeManager;
        }
    }
}