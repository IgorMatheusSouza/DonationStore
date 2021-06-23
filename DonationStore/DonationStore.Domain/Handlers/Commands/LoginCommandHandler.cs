using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Abstractions.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Domain.Handlers.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginUserViewModel>
    {
        private readonly IUserRepository UserRepository;
        private readonly IUserFactory UserFactory;

        public LoginCommandHandler(IUserRepository userRepository, IUserFactory userFactory)
        {
            this.UserRepository = userRepository;
            this.UserFactory = userFactory;
        }
        public async Task<LoginUserViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = UserFactory.Adapt(request);

            var result = await UserRepository.Login(user, request.Password);

            return UserFactory.Adapt(result);
        }
    }
}
