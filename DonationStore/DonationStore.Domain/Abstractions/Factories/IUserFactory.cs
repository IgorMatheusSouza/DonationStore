using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Entities;

namespace DonationStore.Domain.Abstractions.Factories
{
    public interface IUserFactory
    {
        User Adapt(RegisterUserCommand data);

        User Adapt(LoginCommand data);

        UserDetailViewModel Adapt(User data);
    }
}
