using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Home
    {
        public Home()
        {
            Abouts = new HashSet<About>();
            Contacts = new HashSet<Contact>();
            Teammembers = new HashSet<Teammember>();
        }

        public decimal Id { get; set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public string? Imagename { get; set; }
        public decimal? Footerid { get; set; }

        public virtual Footer? Footer { get; set; }
        public virtual ICollection<About> Abouts { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Teammember> Teammembers { get; set; }
    }
}
