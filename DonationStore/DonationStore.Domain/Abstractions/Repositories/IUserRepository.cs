using DonationStore.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DonationStore.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> RegisterUser(User user, string password);

        Task<User> Login(User user, string password);

        Task<User> GetUser(Guid id);

        Task<User> GetUserByEmail(string email);

        Task Logout(string email);
    }
}
