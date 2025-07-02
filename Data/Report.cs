using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Report
    {
        public Report()
        {
            Notifications = new HashSet<Notification>();
        }

        public decimal Id { get; set; }
        public string? Content { get; set; }
        public DateTime? Dtaeofsend { get; set; }
        public decimal? Channelid { get; set; }
        public string? Status { get; set; }

        public virtual Channel? Channel { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
