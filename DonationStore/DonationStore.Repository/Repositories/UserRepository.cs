using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Domain.Entities;
using DonationStore.Enums.DomainEnums;
using DonationStore.Infrastructure.Exceptions;
using DonationStore.Infrastructure.GenericMessages;
using DonationStore.Repository.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DonationStore.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DonationStoreContext DonationStoreContext;
        private readonly UserManager<AppUser> UserManager;

        public UserRepository(DonationStoreContext donationStoreContext, UserManager<AppUser> userManager)
        {
            this.DonationStoreContext = donationStoreContext;
            this.UserManager = userManager;
        }

        public async Task<AppUser> RegisterUser(AppUser user, string password)
        {
            var result = await UserManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new BusinessException(string.Join(DefautlTexts.GenericTextSeparator, result.Errors.Select(x => x.Description)));
            }

            await UserManager.AddToRoleAsync(user, nameof(RolesEnum.User));

            return user;
        }
    }
}
