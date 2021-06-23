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
        private readonly SignInManager<AppUser> SignInManager;

        public UserRepository(DonationStoreContext donationStoreContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.DonationStoreContext = donationStoreContext;
            this.UserManager = userManager;
            this.SignInManager = signInManager;
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

        public async Task<AppUser> Login(AppUser user, string password)
        {
            var result = await SignInManager.PasswordSignInAsync(user.Email, password, false, false);

            if (!result.Succeeded)
            {
                throw new BusinessException(ErrorMessages.LoginError);
            }

            return user;
        }
    }
}
