using DonationStore.Application.Queries.User;
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

namespace DonationStore.Domain.Handlers.Queries.User
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDetailViewModel>
    {
        private readonly IUserRepository UserRepository;
        private readonly IUserFactory UserFactory;

        public GetUserQueryHandler(IUserRepository userRepository, IUserFactory userFactory)
        {
            UserRepository = userRepository;
            UserFactory = userFactory;
        }

        public async Task<UserDetailViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await UserRepository.GetUserByEmail(request.Email);
            return UserFactory.Adapt(user);
        }
    }
}
