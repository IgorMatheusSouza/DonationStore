using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.ViewModels;
using MediatR;
using System.Threading.Tasks;

namespace DonationStore.Application.Services.Abstractions
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public AuthenticationService(IMediator mediator) : base(mediator) { }

        public async Task<LoginUserViewModel> Login(LoginCommand command)
        {
            return await Mediator.Send(command);
        }

        public async Task<LoginUserViewModel> RegisterUser(RegisterUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
