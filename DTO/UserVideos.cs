using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.DTO
{
    public class UserVideos
    {

        public decimal Id { get; set; }
        public string? VideoTitle { get; set; }
        public string? VideoUrl { get; set; }
        public decimal? SizeOfVideo { get; set; }
        public string? Description { get; set; }
        public decimal? ChannelId { get; set; }

        public decimal? Numberoflike { get; set; }
        public decimal? Numberofdislike { get; set; }
        public decimal? Numberofdisplay { get; set; }
        public DateTime? Uploadedate { get; set; }

        public string Imageurl { get; set; }

        public string? ChannelName { get; set; }
        public string? ImageName { get; set; }
    }
}
