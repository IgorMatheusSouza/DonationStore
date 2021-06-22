using DonationStore.Domain.Entities;
using System.Threading.Tasks;

namespace DonationStore.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<AppUser> RegisterUser(AppUser user, string password);
    }
}
