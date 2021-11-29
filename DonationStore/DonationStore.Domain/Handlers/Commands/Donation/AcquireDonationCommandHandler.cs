using DonationStore.Application.Commands.Donation;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Enums.DomainEnums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Domain.Handlers.Commands.Donation
{
    public class AcquireDonationCommandHandler : IRequestHandler<AcquireDonationCommand, Unit>
    {
        private readonly IDonationRepository DonationRepository;
        private readonly IDonationFactory DonationFactory;
        private readonly IDonationAcquisitionRepository DonationAcquisitionRepository;

        public AcquireDonationCommandHandler(IDonationRepository donationRepository, IDonationFactory donationFactory, IDonationAcquisitionRepository donationAcquisitionRepository)
        {
            this.DonationRepository = donationRepository;
            this.DonationFactory = donationFactory;
            this.DonationAcquisitionRepository = donationAcquisitionRepository;
        }

        public async Task<Unit> Handle(AcquireDonationCommand request, CancellationToken cancellationToken)
        {
            await DonationAcquisitionRepository.CreateDonationAcquisition(request.DonationId, request.UserId);
            await DonationRepository.ChangeStatus(DonationEnum.InProgress, request.DonationId);
            return Unit.Task.Result;
        }
    }
}
