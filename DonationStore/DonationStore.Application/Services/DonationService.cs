using DonationStore.Application.Commands.Donation;
using DonationStore.Application.Queries.Donation;
using DonationStore.Application.ViewModels;
using DonationStore.Enums.DomainEnums;
using DonationStore.Infrastructure.Exceptions;
using DonationStore.Infrastructure.Extensions;
using DonationStore.Infrastructure.GenericMessages;
using DonationStore.Infrastructure.Services.Interfaces;
using DonationStore.Infrastructure.Transaction;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationStore.Application.Services.Abstractions
{
    public class DonationService : BaseService, IDonationService
    {
        private readonly IFileInfrastructureService InfrastructureService;

        public DonationService(IMediator mediator, ITransactionScopeManager transactionScopeManager, IFileInfrastructureService infrastructureService) : base(mediator, transactionScopeManager)
        {
            InfrastructureService = infrastructureService;
        }

        public async Task RegisterDonation(RegisterDonationCommand command)
        {
            await Mediator.Send(command);
        }

        public async Task<List<DonationViewModel>> GetDonations(GetDonationsQuery query)
        {
            var donations = await Mediator.Send(query);

            foreach (var donation in donations)
            {
                await LoadDonationImage(donation);
            }

            return donations;
        }

        public async Task<DonationViewModel> GetDonation(GetDonationQuery query)
        {
            var donation = await Mediator.Send(query);
            await LoadDonationImage(donation);
            return donation;
        }

        public async Task AcquireDonation(AcquireDonationCommand command)
        {
            var donation = await Mediator.Send(new GetDonationQuery(command.DonationId));
            if (donation.Status != DonationEnum.Active || donation.User.Id == command.UserId)
                throw new BusinessException(ErrorMessages.AcquireDonationError);

            await Mediator.Send(command);
        }

        public async Task<List<DonationViewModel>> GetDonationAcquisitions(GetDonationAcquisitionsQuery query)
        {
            var donations = await Mediator.Send(query);

            foreach (var donation in donations)
            {
                donation.Images[0].File = await InfrastructureService.LoadImage(donation.Images[0].FileName);
            }
            
            return donations;
        }

        private async Task LoadDonationImage(DonationViewModel donation)
        {
            await Task.Run(async () =>
            {
                var images = donation.Images.Where(x => !x.FileName.IsEmpty());

                foreach (var image in images)
                {
                    image.File = await InfrastructureService.LoadImage(image.FileName);
                }
            });
        }
    }
}
