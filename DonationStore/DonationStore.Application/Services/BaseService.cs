using MediatR;

namespace DonationStore.Application.Services
{
    public abstract class BaseService
    {
        protected BaseService(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        protected IMediator Mediator { get; private set; }
    }
}
