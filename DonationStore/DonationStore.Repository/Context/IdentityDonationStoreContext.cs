using DonationStore.Domain.Entities;
using DonationStore.Repository.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DonationStore.Repository.Context
{
    public class IdentityDonationStoreContext : IdentityDbContext<AppUser>
    {
        public IdentityDonationStoreContext() { }
        public IdentityDonationStoreContext(DbContextOptions<IdentityDonationStoreContext> options) : base(options)
        {
            
        }
    }
}
