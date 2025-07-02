using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface IChannelsubService
    {
        List<Channelsub> GetAllchannel();

        Channelsub GetchannelById(int id);

        void Createchannel(Channelsub channelsub);

        void Updatechannel(Channelsub channelsub);

        Channelsub Deletechannel(int id);

        UserSubscribeDTO GetNumberOfUsersSubs(DateTime startDate, DateTime endDate);

        public int GetUserSu(int subuesrid);

        public void CreateSubscription(SubscribeToChannel subscribeToChannel);

        public bool CheckSubscription(CheckSub CheckSub);


        //public bool CheckSubscription(Channelsub channelsub);
        //public bool CheckSubscription(CheckSub checkSub);

        CheckSub DeleteSubCh(int p_chid, int p_subid);



         int TotalUserSub();
        int GetNumberOfUserSub(int Subuserid);
        List<Channelsub> GetsubBysubuserId(int Subuserid);


    }
}
