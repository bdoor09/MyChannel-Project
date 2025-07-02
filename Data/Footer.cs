using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Footer
    {
        public Footer()
        {
            Homes = new HashSet<Home>();
        }

        public decimal Id { get; set; }
        public string? X { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Whatsapp { get; set; }
        public string? Gmail { get; set; }
        public string? Contents { get; set; }

        public virtual ICollection<Home> Homes { get; set; }
    }
}
