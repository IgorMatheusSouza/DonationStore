using DonationStore.Enums.DomainEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Application.ViewModels
{
    public class DonationAcquisitionViewModel
    {
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public DonationAcquisitionEnum Status { get; set; }
    }
}
