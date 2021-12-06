using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.Constants;
using DonationStore.Infrastructure.CQRS.Implementations;
using MediatR;
using System.Collections.Generic;

namespace DonationStore.Application.Queries.Donation
{
    public class GetDonationsQuery : Request, IRequest<List<DonationViewModel>>
    {
        public GetDonationsQuery(int? incialPage, int? quantity)
        {
            IncialPage = incialPage ?? 0;
            Quantity = quantity ?? SystemConstantValues.DefaultDonationsQuantityPerPage;
        }

        public int IncialPage { get; set; }
        public int Quantity { get; set; }
    }
}
