using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface IChannelService
    {
        void CreateChannel(Channel channel);

        void UpdateChannel(Channel channel);
        void DeleteChannel(int id);
        List<Channel> GetAllChannel();
        Channel GetChannelByID(int id);
        List<SearchChanell> filter(string channelName);

        int TotalChannels();

        List<Channel> GetChannelsByUserId(int userId);

        int countchannel(int Userid);
    }
}
