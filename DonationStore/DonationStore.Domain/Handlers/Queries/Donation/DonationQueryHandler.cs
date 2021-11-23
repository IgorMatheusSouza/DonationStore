using DonationStore.Application.Queries.Donation;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Abstractions.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Domain.Handlers.Queries.Donation
{
    public sealed class DonationQueryHandler : IRequestHandler<GetDonationsQuery, List<DonationViewModel>>, IRequestHandler<GetDonationQuery, DonationViewModel>
    {
        private readonly IDonationRepository DonationRepository;
        private readonly IDonationFactory DonationFactory;

        public DonationQueryHandler(IDonationRepository donationRepository, IDonationFactory donationFactory)
        {
            DonationRepository = donationRepository;
            DonationFactory = donationFactory;
        }

        public async Task<List<DonationViewModel>> Handle(GetDonationsQuery request, CancellationToken cancellationToken)
        {
            var result = await DonationRepository.GetDonations(request.IncialPage, request.Quantity);
            return DonationFactory.Adapt(result);
        }

        public async Task<DonationViewModel> Handle(GetDonationQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
