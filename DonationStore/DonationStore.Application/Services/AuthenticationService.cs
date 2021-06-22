using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Application.Services.Abstractions
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public AuthenticationService(IMediator mediator) : base(mediator) { }

        public async Task<LoginUserViewModel> RegisterUser(RegisterUserCommand command)
        {
            var result = await Mediator.Send(command);
            return (LoginUserViewModel)result;
        }
    }
}
