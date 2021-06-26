using DonationStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Domain.Enities
{
    public class Donation : Entity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual AppUser User { get; set; }
    }
}
