using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Domain.Factories
{
    public class UserFactory : IUserFactory
    {
        public AppUser Adapt(RegisterUserCommand data) => new AppUser { Name = data.Name, Email = data.Email, UserName = data.Email };

        public AppUser Adapt(LoginCommand data) => new AppUser { Email = data.Email, UserName = data.Email };

        public LoginUserViewModel Adapt(AppUser data)
        {
            return new LoginUserViewModel { Email = data.Email, Name = data.Name, Token = data.SecurityStamp };
        }
    }
}
