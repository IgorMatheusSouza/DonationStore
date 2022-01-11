using DonationStore.Enums.DomainEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Application.ViewModels
{
    public class DonationViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public int AddressNumber { get; set; }
        public bool ShowPhoneNumber { get; set; }
        public bool ShowEmail { get; set; }
        public DonationEnum Status { get; set; }
        public DateTime CreationDate { get; set; }
        public GeocodingModel Geocoding { get; set; }
        public UserViewModel User { get; set; }
        public List<DonationImageModel> Images { get; set; } = new();
        public List<DonationAcquisitionViewModel> DonationAcquisitions { get; set; } = new();
    }
}
