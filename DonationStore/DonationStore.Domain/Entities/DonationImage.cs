using DonationStore.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Domain.Entities
{
    public class DonationImage : Entity<Guid>
    {
        public string FileName { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDelete { get; set; }
        public virtual Donation Donation { get; set; }
    }
}
