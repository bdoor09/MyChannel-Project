using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Channelsub
    {
        public decimal Id { get; set; }
        public decimal? Channelid { get; set; }
        public string? Channelname { get; set; }
        public string? Description { get; set; }
        public string? Imagename { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Subuserid { get; set; }

        public virtual User? User { get; set; }
    }
}
