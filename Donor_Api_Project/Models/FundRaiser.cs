using System;
using System.Collections.Generic;

#nullable disable

namespace Donor_Api_Project.Models
{
    public partial class FundRaiser
    {
        public int FundId { get; set; }
        public int? NgoId { get; set; }
        public string FundDescription { get; set; }
        public int? FundPrice { get; set; }

        public virtual Ngo Ngo { get; set; }
    }
}
