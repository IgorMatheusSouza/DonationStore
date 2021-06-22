using DonationStore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DonationStore.Repository.Context
{
    public class IdentityDonationStoreContext : IdentityDbContext<AppUser, AspNetRoles, string>
    {
        public IdentityDonationStoreContext() { }
        public IdentityDonationStoreContext(DbContextOptions<IdentityDonationStoreContext> options) : base(options)
        {
            
        }
    }
}
