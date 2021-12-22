using DonationStore.Application.Commands.Donation;
using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Enums.DomainEnums;
using DonationStore.Infrastructure.Exceptions;
using DonationStore.Infrastructure.GenericMessages;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Domain.Handlers.Commands.Donation
{
    public class ChangeAcquisitionStatusCommandHandler : IRequestHandler<ChangeAcquisitionStatusCommand, Unit>
    {
        private readonly IDonationAcquisitionRepository DonationAcquisitionRepository;
        private readonly IDonationRepository DonationRepository;

        public ChangeAcquisitionStatusCommandHandler(IDonationAcquisitionRepository donationAcquisitionRepository, IDonationRepository donationRepository)
        {
            DonationAcquisitionRepository = donationAcquisitionRepository;
            DonationRepository = donationRepository;
        }

        public async Task<Unit> Handle(ChangeAcquisitionStatusCommand request, CancellationToken cancellationToken)
        {
            var donation = await DonationAcquisitionRepository.GetDonationAcquisition(request.DonationId);
            var donationAcquisition = donation?.Acquisitions?.FirstOrDefault(x => x.Status == DonationAcquisitionEnum.Active);

            if (donation == null || donationAcquisition == null)
                throw new BusinessException(ErrorMessages.InvalidData);

            if (request.Status == DonationAcquisitionEnum.Active)
            {
                await DonationRepository.ChangeStatus(DonationEnum.Reserved, donation.Id);
            }
            else
            {
                await DonationAcquisitionRepository.ChangeAcquisitionStatus(donationAcquisition.Id, request.Status);

                if (request.Status == DonationAcquisitionEnum.Cancelled)
                    await DonationRepository.ChangeStatus(DonationEnum.Active, donation.Id);

                else if (request.Status == DonationAcquisitionEnum.Completed)
                    await DonationRepository.ChangeStatus(DonationEnum.Completed, donation.Id);
            }

            return Unit.Task.Result;
        }
    }
}
