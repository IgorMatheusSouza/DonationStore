using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Domain.Handlers.Commands.Users
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository UserRepository;
        private readonly IUserFactory UserFactory;

        public RegisterUserCommandHandler(IUserRepository userRepository, IUserFactory userFactory)
        {
            this.UserRepository = userRepository;
            this.UserFactory = userFactory;
        }

        public async Task<LoginUserViewModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = UserFactory.Adapt(request);

            var result = await UserRepository.RegisterUser(user, request.Password);

            return UserFactory.Adapt(result);
        }
    }
}
