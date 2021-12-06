using DonationStore.Application.Commands.Donation;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Infrastructure.Exceptions;
using DonationStore.Infrastructure.GenericMessages;
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
        private readonly IUserRepository UserRepository;

        public RegisterDonationCommandHandler(IDonationRepository donationRepository, IDonationFactory donationFactory, IUserRepository userRepository)
        {
            DonationRepository = donationRepository;
            DonationFactory = donationFactory;
            UserRepository = userRepository;
        }

        public async Task<Unit> Handle(RegisterDonationCommand request, CancellationToken cancellationToken)
        {
            var user = await UserRepository.GetUserByEmail(request.LoginUser.Email);

            if (user.SecurityStamp != request.LoginUser.Token)
                throw new AuthorizationException(ErrorMessages.AuthError);

            var donation = DonationFactory.Adapt(request);
            donation.User = user;

            await DonationRepository.RegisterDonation(donation);
            return Unit.Task.Result;
        }
    }
}