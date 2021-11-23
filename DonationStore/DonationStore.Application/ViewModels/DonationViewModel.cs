using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Application.ViewModels
{
    public class DonationViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual UserViewModel User { get; set; }
        public virtual ICollection<DonationImageModel> Images { get; set; }
    }
}
