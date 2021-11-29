using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.CQRS.Implementations;
using MediatR;
using System;

namespace DonationStore.Application.Queries.User
{
    public class GetUserQuery : Request, IRequest<UserDetailViewModel>
    {
        public GetUserQuery(Guid id)
        {
            Id = id;
        }

        public GetUserQuery(string email)
        {
            this.Email = email;
        }

        public Guid Id { get; set; }

        public string Email { get; set; }
    }
}
