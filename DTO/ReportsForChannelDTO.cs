using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.DTO
{
    public class ReportsForChannelDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateOfSend { get; set; } // Assuming DTAEOFSEND is a date or timestamp
        public string ChannelName { get; set; }
    }
}
