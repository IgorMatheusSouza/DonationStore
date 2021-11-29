using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Application.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public Guid Id { get; set; }
    }
}
