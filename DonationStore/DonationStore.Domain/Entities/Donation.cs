using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Domain.Enities
{
    public class Donation : Entity<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

    }
}
