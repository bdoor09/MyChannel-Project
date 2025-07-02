using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Feedback
    {
        public decimal Id { get; set; }
        public string? Content { get; set; }
        public DateTime? Dtaeofsend { get; set; }
        public decimal? Userid { get; set; }

        public virtual User? User { get; set; }
    }
}
