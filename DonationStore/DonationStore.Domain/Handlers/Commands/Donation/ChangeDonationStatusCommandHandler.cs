using DonationStore.Application.Commands.Donation;
using DonationStore.Domain.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Domain.Handlers.Commands.Donation
{
    public class ChangeDonationStatusCommandHandler : IRequestHandler<ChangeDonationStatusCommand, Unit>
    {
        private readonly IDonationRepository DonationRepository;

        public ChangeDonationStatusCommandHandler(IDonationRepository donationRepository)
        {
            DonationRepository = donationRepository;
        }

        public async Task<Unit> Handle(ChangeDonationStatusCommand request, CancellationToken cancellationToken)
        {
            await DonationRepository.ChangeStatus(request.Status, request.DonationId);
            return Unit.Task.Result;
        }
    }
}
