using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Video
    {
        public Video()
        {
            Comments = new HashSet<Comment>();
        }

        public decimal Id { get; set; }
        public string? Videotitle { get; set; }
        public string? Videourl { get; set; }
        public decimal? Sizeofvideo { get; set; }
        public string? Description { get; set; }
        public decimal? Channelid { get; set; }
        public decimal? Numberoflike { get; set; }
        public decimal? Numberofdislike { get; set; }
        public decimal? Numberofdisplay { get; set; }
        public DateTime? Uploadedate { get; set; }
        public string? Imageurl { get; set; }

        public virtual Channel? Channel { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
