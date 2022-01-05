using DonationStore.Domain.Entities;
using DonationStore.Enums.DomainEnums;
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
        public string District { get; set; }
        public string ZipCode { get; set; }
        public DateTime CreationDate { get; set; }
        public bool ShowPhoneNumber { get; set; }
        public bool ShowEmail { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DonationEnum Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<DonationImage> Images { get; set; }
        public virtual ICollection<DonationAcquisition> Acquisitions { get; set; }
    }
}
