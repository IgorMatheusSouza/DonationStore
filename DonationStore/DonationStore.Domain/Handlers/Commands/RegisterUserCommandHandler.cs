using DonationStore.Application.Commands.Authentication;
using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Domain.Handlers.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser {
                Name = request.Name, 
                Email = request.Email,
                UserName = request.Email
            };

            await this.userRepository.RegisterUser(user, request.Password);
            return Unit.Task.Result;
        }
    }
}
