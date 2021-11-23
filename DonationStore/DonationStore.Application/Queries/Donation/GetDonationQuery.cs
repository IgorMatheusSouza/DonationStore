using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.CQRS.Implementations;
using MediatR;

namespace DonationStore.Application.Queries.Donation
{
    public class GetDonationQuery : Request, IRequest<DonationViewModel>
    {

    }
}
