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
    public class ChannelsubService: IChannelsubService
    {
        private readonly IChannelsubRepository channelsubRepository;

        public ChannelsubService(IChannelsubRepository channelsubRepository)
        {
            this.channelsubRepository = channelsubRepository;
        }

        public List<Channelsub> GetAllchannel()
        {
            return channelsubRepository.GetAllchannel();

        }

        public Channelsub GetchannelById(int id)
        {
            return channelsubRepository.GetchannelById(id);
        }

        public void Createchannel(Channelsub channelsub)
        {
            channelsubRepository.Createchannel(channelsub);
        }

        public void Updatechannel(Channelsub channelsub)
        {
            channelsubRepository.Updatechannel(channelsub);
        }
        public Channelsub Deletechannel(int id)
        {
            return channelsubRepository.Deletechannel(id);
        }


        public  UserSubscribeDTO GetNumberOfUsersSubs(DateTime startDate, DateTime endDate)
        {
            return channelsubRepository.GetNumberOfUsersSubs(startDate, endDate);

        }

        public int GetUserSu(int subuesrid)
        {
            return channelsubRepository.GetUserSu(subuesrid);
        }

        public void CreateSubscription(SubscribeToChannel subscribeToChannel)
        {
            channelsubRepository.CreateSubscription(subscribeToChannel);
        }


        public bool CheckSubscription(CheckSub checkSub)
        {
            return channelsubRepository.CheckSubscription(checkSub);
        }



        //public bool CheckSubscription(Channelsub channelsub)
        //{
        //    return channelsubRepository.CheckSubscription(channelsub);
        //}


        public CheckSub DeleteSubCh(int p_chid, int p_subid)
        {
            return channelsubRepository.DeleteSubCh(p_chid, p_subid);
        }


        public int TotalUserSub()
        {
            return channelsubRepository.TotalUserSub();
        }



        public int GetNumberOfUserSub(int Subuserid)
        {
            return channelsubRepository.GetNumberOfUserSub(Subuserid);
        }


        public List<Channelsub> GetsubBysubuserId(int Subuserid)
        {
            return channelsubRepository.GetsubBysubuserId(Subuserid);
        }

        //public bool CheckSubscription(CheckSub checkSub)
        //{
        //    return channelsubRepository.CheckSubscription(checkSub);
        //}




    }
}
