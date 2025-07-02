using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Notification
    {
        public decimal Nid { get; set; }
        public string? Message { get; set; }
        public DateTime? Dtaeofsend { get; set; }
        public string? Status { get; set; }
        public decimal? Reportid { get; set; }

        public virtual Report? Report { get; set; }
    }
}
