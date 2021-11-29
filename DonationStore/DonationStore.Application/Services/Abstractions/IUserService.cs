using DonationStore.Application.Queries.User;
using DonationStore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Application.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser(GetUserQuery getUserQuery);
    }
}
