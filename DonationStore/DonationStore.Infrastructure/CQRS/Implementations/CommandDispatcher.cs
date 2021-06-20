using DonationStore.Infrastructure.CQRS.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Infrastructure.CQRS.Implementations
{
    public class CommandDispatcher : ICommandDispatcher
    {
        protected IMediator Mediator { get; private set; }

        public CommandDispatcher(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        public Task<ICommandResult> Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
            return null;
        }
    }
}
