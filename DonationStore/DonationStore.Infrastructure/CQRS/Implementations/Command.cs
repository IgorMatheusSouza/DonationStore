using MediatR;

namespace DonationStore.Infrastructure.CQRS.Implementations
{
    public abstract class Command<TMessage> : IRequest
    {
        protected Command(TMessage message)
        {
            this.Message = message;
        }

        public TMessage Message { get; private set; }
    }
}