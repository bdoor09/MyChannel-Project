using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Payment
    {
        public Payment()
        {
        
        }

        public decimal Id { get; set; }
        public string? Cardholdername { get; set; }
        public decimal? Cardnumber { get; set; }
        public decimal? Cvv { get; set; }
        public DateTime? Expirydate { get; set; }
        public DateTime? Paymentdate { get; set; }
        public decimal? Totalamount { get; set; }
        public decimal? Userid { get; set; }

        public virtual User? User { get; set; }
   
    }
}
