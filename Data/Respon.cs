using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Respon
    {
        public decimal Id { get; set; }
        public string? Replaycomment { get; set; }
        public decimal? Commentid { get; set; }
        public decimal? Usercid { get; set; }

        public virtual Comment? Comment { get; set; }
        public virtual User? Userc { get; set; }
    }
}
