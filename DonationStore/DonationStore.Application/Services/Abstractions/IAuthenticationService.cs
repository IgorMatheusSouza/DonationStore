using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Application.Services.Abstractions
{
    public interface IAuthenticationService
    {
        Task<LoginUserViewModel> RegisterUser(RegisterUserCommand command);
    }
}
