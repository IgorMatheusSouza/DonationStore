using DonationStore.Application.ViewModels;
using DonationStore.Infrastructure.CQRS.Implementations;

namespace DonationStore.Application.Commands.Authentication
{
    public class UserCommand 
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}