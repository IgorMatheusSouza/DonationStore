using DonationStore.Application.Commands.Authentication;
using DonationStore.Domain.Abstractions.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Domain.Handlers.Commands.User
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly IUserRepository UserRepository;

        public LogoutCommandHandler(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await this.UserRepository.Logout(request.Email);
            return Unit.Task.Result;
        }
    }
}
