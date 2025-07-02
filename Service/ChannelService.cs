using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using MyChannel.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Service
{
    public class ChannelService: IChannelService
    {
        private readonly IChannelRepository ChannelRepoistory;

        public ChannelService(IChannelRepository _channelRepoistory)
        {
            this.ChannelRepoistory = _channelRepoistory;
        }

        public void CreateChannel(Channel channel)
        {
            ChannelRepoistory.CreateChannel(channel);
        }

        public void UpdateChannel(Channel channel)
        {
            ChannelRepoistory.UpdateChannel(channel);
        }

        public void DeleteChannel(int id)
        {
            ChannelRepoistory.DeleteChannel(id);
        }



        public Channel GetChannelByID(int id)
        {
            return ChannelRepoistory.GetChannelByID(id);
        }

        public List<Channel> GetAllChannel()
        {
            return ChannelRepoistory.GetAllChannel();
        }

        public List<SearchChanell> filter(string channelName)
        {
            return ChannelRepoistory.filter(channelName);
        }

        public int TotalChannels()
        {
            return ChannelRepoistory.TotalChannels();   
        }

        public List<Channel> GetChannelsByUserId(int userId)
        {
            return ChannelRepoistory.GetChannelsByUserId(userId);
        }

        public int countchannel(int Userid)
        {
            return ChannelRepoistory.countchannel(Userid);
        }
    }
}
