using DonationStore.Application.Queries.Donation;
using DonationStore.Application.ViewModels;
using DonationStore.Domain.Abstractions.Factories;
using DonationStore.Domain.Abstractions.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Domain.Handlers.Queries.Donation
{
    public class DonationAcquisitionQueryHandler : IRequestHandler<GetDonationAcquisitionsQuery, List<DonationViewModel>>
    {
        private readonly IDonationAcquisitionRepository DonationAcquisitionRepository;
        private readonly IDonationFactory DonationFactory;

        public DonationAcquisitionQueryHandler(IDonationAcquisitionRepository donationAcquisitionRepository, IDonationFactory donationFactory)
        {
            DonationAcquisitionRepository = donationAcquisitionRepository;
            DonationFactory = donationFactory;
        }

        public async Task<List<DonationViewModel>> Handle(GetDonationAcquisitionsQuery request, CancellationToken cancellationToken)
        {
            var result =  await DonationAcquisitionRepository.GetDonationAcquisitions(request.UserID);
            return DonationFactory.Adapt(result);

        }
    }
}
