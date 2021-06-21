using DonationStore.Domain.Enities;
using DonationStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonationStore.Repository.Context
{
    public class DonationStoreContext : DbContext
    {
        public DonationStoreContext(DbContextOptions<DonationStoreContext> options) : base(options) { }

        public DbSet<Donation> Donations { get; set; }

        public DbSet<AppUser> Users { get; set; }

        public DbSet<AppRole> Roles { get; set; }
    }
}

