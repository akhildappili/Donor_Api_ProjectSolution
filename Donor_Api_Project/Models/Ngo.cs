using System;
using System.Collections.Generic;

#nullable disable

namespace Donor_Api_Project.Models
{
    public partial class Ngo
    {
        public Ngo()
        {
            Donations = new HashSet<Donation>();
            EventFunds = new HashSet<EventFund>();
            Verifications = new HashSet<Verification>();
        }

        public int NgoId { get; set; }
        public string NgoName { get; set; }
        public string NgoPhoneNumber { get; set; }
        public string NgoMailId { get; set; }
        public string NgoAddress { get; set; }
        public string NgoUserName { get; set; }
        public string NgoPassword { get; set; }
        public string NgoConfirmPassword { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<EventFund> EventFunds { get; set; }
        public virtual ICollection<Verification> Verifications { get; set; }
    }
}
