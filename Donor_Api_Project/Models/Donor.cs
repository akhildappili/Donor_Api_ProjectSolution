using System;
using System.Collections.Generic;

#nullable disable

namespace Donor_Api_Project.Models
{
    public partial class Donor
    {
        public Donor()
        {
            Donations = new HashSet<Donation>();
        }

        public int DonorId { get; set; }
        public string DonorName { get; set; }
        public string DonorPhoneNumber { get; set; }
        public string DonorMailId { get; set; }
        public string DonorUserName { get; set; }
        public string DonorPassword { get; set; }
        public string DonorConfirmPassword { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
    }
}
