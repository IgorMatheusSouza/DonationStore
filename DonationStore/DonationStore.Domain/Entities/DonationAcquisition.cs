using DonationStore.Domain.Enities;
using DonationStore.Enums.DomainEnums;
using System;

namespace DonationStore.Domain.Entities
{
    public class DonationAcquisition : Entity<Guid>
    {
        public Guid DonationId { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public DonationAcquisitionEnum Status { get; set; }
        public virtual Donation Donation { get; set; }
        public virtual User User { get; set; }
    }
}
