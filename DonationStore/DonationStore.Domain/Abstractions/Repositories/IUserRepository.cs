using DonationStore.Domain.Entities;
using System.Threading.Tasks;

namespace DonationStore.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<AspNetUsers> RegisterUser(AspNetUsers user, string password);

        Task<AspNetUsers> Login(AspNetUsers user, string password);

        Task<AspNetUsers> GetUser(string id);

        AspNetUsers GetUserByEmail(string email);
    }
}
