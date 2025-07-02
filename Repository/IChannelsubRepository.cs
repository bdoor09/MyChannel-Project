using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Repository
{
    public interface IChannelsubRepository
    {
        List<Channelsub> GetAllchannel();

        Channelsub GetchannelById(int id);

        void Createchannel(Channelsub channelsub);

        void Updatechannel(Channelsub channelsub);

        Channelsub Deletechannel(int id);

        UserSubscribeDTO GetNumberOfUsersSubs(DateTime startDate, DateTime endDate);


         int GetUserSu(int subuesrid);

         void CreateSubscription(SubscribeToChannel subscribeToChannel);


        public bool CheckSubscription(CheckSub CheckSub);


        //bool CheckSubscription(Channelsub channelsub);

        //public bool CheckSubscription(CheckSub checkSub);

        CheckSub DeleteSubCh(int p_chid, int p_subid);


        int TotalUserSub();

         int GetNumberOfUserSub(int Subuserid);
         List<Channelsub> GetsubBysubuserId(int Subuserid);


    }
}
