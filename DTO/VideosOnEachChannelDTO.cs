using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.DTO
{
    public class VideosOnEachChannelDTO
    {
        public string? ChannelName { get; set; }

        public decimal channelid { get; set; }
        public int VideoCount { get; set; }
    }
}
