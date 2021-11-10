using DonationStore.Application.Commands.Donation;
using DonationStore.Infrastructure.Transaction;
using MediatR;
using System.Threading.Tasks;

namespace DonationStore.Application.Services.Abstractions
{
    public class DonationService : BaseService, IDonationService
    {
        public DonationService(IMediator mediator, ITransactionScopeManager transactionScopeManager) : base(mediator, transactionScopeManager) { }

        public async Task RegisterDonation(RegisterDonationCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
