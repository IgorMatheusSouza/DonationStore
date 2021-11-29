using DonationStore.Application.Commands.Authentication;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Entities;
using System;

namespace DonationStore.Domain.Factories
{
    public class UserFactory : IUserFactory
    {
        public User Adapt(RegisterUserCommand data) => new() { Name = data.Name, Email = data.Email, UserName = data.Email };

        public User Adapt(LoginCommand data) => new() { Email = data.Email, UserName = data.Email };

        public UserDetailViewModel Adapt(User data) => new() { Email = data.Email, Name = data.Name, Token = data.SecurityStamp, Phone = data.PhoneNumber, Id = Guid.Parse(data.Id) };
    }
}
