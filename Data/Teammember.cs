using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Teammember
    {
        public decimal Id { get; set; }
        public string? Membername { get; set; }
        public string? Role { get; set; }
        public string? Imagename { get; set; }
        public string? Email { get; set; }
        public decimal? Homeid { get; set; }
        public string? Phonenumber { get; set; }
        public string? Linkedin { get; set; }

        public virtual Home? Home { get; set; }
    }
}
