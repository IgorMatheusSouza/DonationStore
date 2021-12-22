using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.CQRS.Implementations;
using MediatR;
using System;
using System.Collections.Generic;

namespace DonationStore.Application.Queries.Donation
{
    public class GetUserDonationsQuery : Request, IRequest<List<DonationViewModel>>
    {
        public GetUserDonationsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
