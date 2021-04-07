using System;
using System.Collections.Generic;

#nullable disable

namespace Donor_Api_Project.Models
{
    public partial class Verification
    {
        public int VerificationId { get; set; }
        public int? NgoId { get; set; }
        public string ProofOfVerification { get; set; }
        public string Status { get; set; }

        public virtual Ngo Ngo { get; set; }
    }
}
