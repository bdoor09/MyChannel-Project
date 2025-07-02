using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Channel
    {
        public Channel()
        {
            Reports = new HashSet<Report>();
            Videos = new HashSet<Video>();
        }

        public decimal Id { get; set; }
        public string? Channelname { get; set; }
        public string? Description { get; set; }
        public string? Imagename { get; set; }
        public decimal? Userid { get; set; }
        public string? Backimage { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
