using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class About
    {
        public decimal Id { get; set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public string? Imagename { get; set; }
        public decimal? Homeid { get; set; }

        public virtual Home? Home { get; set; }
    }
}
