using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.Transaction;
using MediatR;
using System.Threading.Tasks;

namespace DonationStore.Application.Services.Abstractions
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public AuthenticationService(IMediator mediator, ITransactionScopeManager transactionScopeManager) : base(mediator, transactionScopeManager) { }

        public async Task<UserViewModel> Login(LoginCommand command)
        {
            return await Mediator.Send(command);
        }

        public async Task Logout(UserViewModel model)
        {
            await Mediator.Send(new LogoutCommand { Email = model.Email, Token = model.Token });
        }

        public async Task<UserViewModel> RegisterUser(RegisterUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
