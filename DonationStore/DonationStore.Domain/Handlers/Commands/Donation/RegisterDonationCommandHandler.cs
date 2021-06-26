using DonationStore.Application.Commands.Donation;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Abstractions.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Domain.Handlers.Commands.Donation
{
    public class RegisterDonationCommandHandler : IRequestHandler<RegisterDonationCommand, Unit>
    {
        private readonly IDonationRepository DonationRepository;
        private readonly IDonationFactory DonationFactory;

        public RegisterDonationCommandHandler(IDonationRepository donationRepository, IDonationFactory donationFactory)
        {
            this.DonationRepository = donationRepository;
            this.DonationFactory = donationFactory;
        }

        public async Task<Unit> Handle(RegisterDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = DonationFactory.Adapt(request);
            await DonationRepository.RegisterDonation(donation);

            return Unit.Task.Result;
        }
    }
}