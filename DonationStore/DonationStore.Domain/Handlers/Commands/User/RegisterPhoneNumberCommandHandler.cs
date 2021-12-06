using DonationStore.Application.Commands.User;
using DonationStore.Domain.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DonationStore.Domain.Handlers.Commands.User
{
    public class RegisterPhoneNumberCommandHandler : IRequestHandler<RegisterPhoneNumberCommand>
    {
        private readonly IUserRepository UserRepository;

        public RegisterPhoneNumberCommandHandler(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }

        public async Task<Unit> Handle(RegisterPhoneNumberCommand request, CancellationToken cancellationToken)
        {
            await UserRepository.RegisterPhone(request.UserId , request.PhoneNumber);
            return Unit.Task.Result;
        }
    }
}
