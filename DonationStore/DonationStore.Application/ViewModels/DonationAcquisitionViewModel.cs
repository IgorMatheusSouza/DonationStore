using DonationStore.Enums.DomainEnums;
using System;

namespace DonationStore.Application.ViewModels
{
    public class DonationAcquisitionViewModel
    {
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public DonationAcquisitionEnum Status { get; set; }
        public UserDetailViewModel User { get; set; }
    }
}
