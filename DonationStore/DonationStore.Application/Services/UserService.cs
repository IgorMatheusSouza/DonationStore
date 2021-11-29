using DonationStore.Application.Queries.User;
using DonationStore.Application.Services.Abstractions;
using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Application.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IMediator mediator, ITransactionScopeManager transactionScopeManager) : base(mediator, transactionScopeManager)
        {

        }

        public async Task<UserViewModel> GetUser(GetUserQuery Query)
        {
            return await this.Mediator.Send(Query);
        }
    }
}
