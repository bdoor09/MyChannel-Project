using System;
using System.Collections.Generic;

namespace MyChannel.Core.Data
{
    public partial class Comment
    {
        public Comment()
        {
            Respons = new HashSet<Respon>();
        }

        public decimal Id { get; set; }
        public string? Content { get; set; }
        public DateTime? Commentdate { get; set; }
        public decimal? Videoid { get; set; }
        public decimal? Userid { get; set; }

        public virtual User? User { get; set; }
        public virtual Video? Video { get; set; }
        public virtual ICollection<Respon> Respons { get; set; }
    }
}
