using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.DTO
{
    public class GetFeedbackuser
    {
        public decimal Id { get; set; }
        public decimal? UserId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Image { get; set; }

        public string? Content { get; set; }
        public DateTime? DtaeOfSend { get; set; }
    }
}
