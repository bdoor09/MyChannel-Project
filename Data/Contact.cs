using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Contact
    {
        public decimal Id { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public string? Email { get; set; }
        public decimal? Homeid { get; set; }

        public virtual Home? Home { get; set; }
    }
}
