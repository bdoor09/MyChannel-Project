using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Feature
    {
        public decimal Id { get; set; }
        public string? Title { get; set; }
        public string? Con1 { get; set; }
        public string? Con2 { get; set; }
        public string? Con3 { get; set; }
        public string? Imagename { get; set; }
        public decimal? Homeid { get; set; }
    }
}
