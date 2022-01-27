using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.Constants;
using DonationStore.Infrastructure.CQRS.Implementations;
using MediatR;
using System.Collections.Generic;

namespace DonationStore.Application.Queries.Donation
{
    public class GetDonationsQuery : Request, IRequest<List<DonationViewModel>>
    {
        public GetDonationsQuery(int? incialPage, int? quantity, string searchWord = null, string searchPlace = null)
        {
            IncialPage = incialPage ?? 0;
            Quantity = quantity ?? SystemConstantValues.DefaultDonationsQuantityPerPage;
            SearchWord = searchWord?.ToLower();
            SearchPlace = searchPlace?.ToLower();
        }

        public int IncialPage { get; set; }
        public int Quantity { get; set; }
        public string SearchWord { get; set; }
        public string SearchPlace { get; set; }

    }
}
