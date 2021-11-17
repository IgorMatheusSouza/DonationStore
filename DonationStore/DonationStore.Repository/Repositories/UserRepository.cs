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
        private readonly UserManager<AspNetUsers> UserManager;
        private readonly SignInManager<AspNetUsers> SignInManager;

        public UserRepository(DonationStoreContext donationStoreContext, UserManager<AspNetUsers> userManager, SignInManager<AspNetUsers> signInManager)
        {
            this.DonationStoreContext = donationStoreContext;
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        public async Task<AspNetUsers> RegisterUser(AspNetUsers user, string password)
        {
            var result = await UserManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new BusinessException(string.Join(DefautlTexts.GenericTextSeparator, result.Errors.Select(x => x.Description)));
            }

            await UserManager.AddToRoleAsync(user, nameof(RolesEnum.User));

            return user;
        }

        public async Task<AspNetUsers> Login(AspNetUsers user, string password)
        {
            var result = await SignInManager.PasswordSignInAsync(user.Email, password, false, false);

            if (!result.Succeeded)
            {
                throw new BusinessException(ErrorMessages.LoginError);
            }

            return user;
        }

        public async Task<AspNetUsers> GetUser(string id)
        {
            return await DonationStoreContext.Users.FindAsync(id);
        }

        public AspNetUsers GetUserByEmail(string email)
        {
            return DonationStoreContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public async Task logout(string email)
        {
            await SignInManager.SignOutAsync();
        }
    }
}
