using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.DTO
{
    public class SearchReDate
    {

        public string? Content { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime? DtaeOfSend { get; set; }

        public string? ChannelName { get; set; }
        public string? ImageName { get; set; }

        public string? Firstname { get; set; }

        public string? Emaile { get; set; }

        public DateTime? RegisterDate { get; set; }
    }
}
