using DonationStore.Domain.Abstractions.Repositories;
using DonationStore.Domain.Entities;
using DonationStore.Repository.Context;
using DonationStore.Repository.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task RegisterUser(AppUser user, string password)
        {
            var result = await this.UserManager.CreateAsync(user, password);

            await this.UserManager.AddToRoleAsync(user, "User");

            throw new NotImplementedException();
        }
    }
}
