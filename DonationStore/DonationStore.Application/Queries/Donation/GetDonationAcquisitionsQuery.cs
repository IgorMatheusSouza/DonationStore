using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.CQRS.Implementations;
using MediatR;
using System;
using System.Collections.Generic;

namespace DonationStore.Application.Queries.Donation
{
    public class GetDonationAcquisitionsQuery : Request, IRequest<List<DonationViewModel>>
    {
        public GetDonationAcquisitionsQuery(Guid userid)
        {
            UserID = userid;
        }

        public Guid UserID { get; set; }
    }
}