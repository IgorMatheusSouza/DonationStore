using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.CQRS.Implementations;
using MediatR;
using System;

namespace DonationStore.Application.Queries.Donation
{
    public class GetDonationQuery : Request, IRequest<DonationViewModel>
    {
        public GetDonationQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
