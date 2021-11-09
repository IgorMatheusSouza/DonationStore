using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Entities;

namespace DonationStore.Domain.Abstractions.Factories
{
    public interface IUserFactory
    {
        AspNetUsers Adapt(RegisterUserCommand data);

        AspNetUsers Adapt(LoginCommand data);

        LoginUserViewModel Adapt(AspNetUsers data);
    }
}
