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
        public AspNetUsers Adapt(RegisterUserCommand data) => new AspNetUsers { Name = data.Name, Email = data.Email, UserName = data.Email };

        public AspNetUsers Adapt(LoginCommand data) => new AspNetUsers { Email = data.Email, UserName = data.Email };

        public LoginUserViewModel Adapt(AspNetUsers data) => new LoginUserViewModel { Email = data.Email, Name = data.Name, Token = data.SecurityStamp };
        
    }
}
