using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.DTO
{
    public class RepotChanel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? DtaeOfSend { get; set; }
        public string ChannelName { get; set; }

        public string? Status { get; set; }
    }
}
