using Microsoft.AspNetCore.Identity;
using System;

namespace DonationStore.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string CPF { get; set; }

        public DateTime? BirthDate { get; set; }

        public string ProfilePicture { get; set; }
    }
}
