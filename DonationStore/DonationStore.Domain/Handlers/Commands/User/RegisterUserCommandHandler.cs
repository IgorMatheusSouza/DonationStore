using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Domain.Handlers.Commands.Users
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserViewModel>
    {
        private readonly IUserRepository UserRepository;
        private readonly IUserFactory UserFactory;

        public RegisterUserCommandHandler(IUserRepository userRepository, IUserFactory userFactory)
        {
            this.UserRepository = userRepository;
            this.UserFactory = userFactory;
        }

        public async Task<UserViewModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = UserFactory.Adapt(request);
            await UserRepository.RegisterUser(user, request.Password);
            var result = UserRepository.GetUserByEmail(user.Email);

            return UserFactory.Adapt(result);
        }
    }
}
