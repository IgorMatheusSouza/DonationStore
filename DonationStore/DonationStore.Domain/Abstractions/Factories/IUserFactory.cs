﻿using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Entities;

namespace DonationStore.Domain.Abstractions.Factories
{
    public interface IUserFactory
    {
        AppUser Adapt(RegisterUserCommand data);

        AppUser Adapt(LoginCommand data);

        LoginUserViewModel Adapt(AppUser data);
    }
}
