using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.DTO
{
    public class InfoUserPayment
    {
        public DateTime? Paymentdate { get; set; }
        public decimal? Totalamount { get; set; }


        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Emaile { get; set; }
    }
}
