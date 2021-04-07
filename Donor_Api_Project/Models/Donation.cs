using System;
using System.Collections.Generic;

#nullable disable

namespace Donor_Api_Project.Models
{
    public partial class Donation
    {
        public int TransactionId { get; set; }
        public int? DonorId { get; set; }
        public int? NgoId { get; set; }
        public int? Amount { get; set; }
        public string Description { get; set; }

        public virtual Donor Donor { get; set; }
        public virtual Ngo Ngo { get; set; }
    }
}
