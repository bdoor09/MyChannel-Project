using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.DTO
{
    public class CommentDto
    {
        public decimal Id { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Image { get; set; }
        public decimal? Videoid { get; set; }
    }
}
