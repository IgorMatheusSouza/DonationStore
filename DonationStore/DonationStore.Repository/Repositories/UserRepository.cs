using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Domain.Entities;
using DonationStore.Enums.DomainEnums;
using DonationStore.Infrastructure.Exceptions;
using DonationStore.Infrastructure.GenericMessages;
using DonationStore.Repository.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DonationStore.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DonationStoreContext DonationStoreContext;
        private readonly UserManager<User> UserManager;
        private readonly SignInManager<User> SignInManager;

        public UserRepository(DonationStoreContext donationStoreContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.DonationStoreContext = donationStoreContext;
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        public async Task<User> RegisterUser(User user, string password)
        {
            var result = await UserManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new BusinessException(string.Join(DefautlTexts.GenericTextSeparator, result.Errors.Select(x => x.Description)));
            }

            await UserManager.AddToRoleAsync(user, nameof(RolesEnum.User));

            return user;
        }

        public async Task<User> Login(User user, string password)
        {
            var result = await SignInManager.PasswordSignInAsync(user.Email, password, false, false);

            if (!result.Succeeded)
            {
                throw new BusinessException(ErrorMessages.LoginError);
            }

            return user;
        }

        public async Task<User> GetUser(Guid id)
        {
            return await DonationStoreContext.Users.FindAsync(id.ToString());
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await DonationStoreContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task Logout(string email)
        {
            await SignInManager.SignOutAsync();
        }

        public async Task RegisterPhone(Guid id, string phone)
        {
            var user = await GetUser(id);
            user.PhoneNumber = phone;
            await DonationStoreContext.SaveChangesAsync();
        }
    }
}
