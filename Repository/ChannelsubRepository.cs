using Dapper;
using MyChannel.Core.Commen;
using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static MyChannel.Core.DTO.SubscribeToChannel;

namespace MyChannel.Infra.Repository
{
    public class ChannelsubRepository : IChannelsubRepository
    {
        private readonly IDbContext dbContext;

        public ChannelsubRepository(IDbContext dbContext)

        {

            this.dbContext = dbContext;

        }

        public List<Channelsub> GetAllchannel()

        {

            IEnumerable<Channelsub> result = dbContext.Connection.Query<Channelsub>("CHANNELSUB_Package.GET_ALL", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }

        public Channelsub GetchannelById(int id)

        {

            var p = new DynamicParameters();

            p.Add("cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Query<Channelsub>("CHANNELSUB_Package.GET_CHANNELSUB_BY_ID", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();

        }

        public void Createchannel(Channelsub channelsub)

        {

            var p = new DynamicParameters();

            p.Add("channel_id", channelsub.Channelid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("channel_name", channelsub.Channelname, DbType.String, direction: ParameterDirection.Input);
            p.Add("descrip", channelsub.Description, DbType.String, direction: ParameterDirection.Input);
            p.Add("image_name", channelsub.Imagename, DbType.String, direction: ParameterDirection.Input);
            p.Add("USER_ID", channelsub.Userid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("sub_use", channelsub.Subuserid, DbType.Int32, direction: ParameterDirection.Input);



            var result = dbContext.Connection.Execute("CHANNELSUB_Package.CREAT_NEW_CHANNELSUB", p, commandType: CommandType.StoredProcedure);

        }

        public void Updatechannel(Channelsub channelsub)

        {

            var p = new DynamicParameters();

            p.Add("cid", channelsub.Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("channel_name", channelsub.Channelname, DbType.String, direction: ParameterDirection.Input);
            p.Add("descrip", channelsub.Description, DbType.String, direction: ParameterDirection.Input);
            p.Add("image_name", channelsub.Imagename, DbType.String, direction: ParameterDirection.Input);
            p.Add("USER_ID", channelsub.Userid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("sub_use", channelsub.Subuserid, DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("CHANNELSUB_Package.UPDATE_of_CHANNELSUB", p, commandType: CommandType.StoredProcedure);

        }

        public Channelsub Deletechannel(int id)

        {

            var p = new DynamicParameters();

            p.Add("cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Query<Channelsub>("CHANNELSUB_Package.DELETE_CHANNELSUB", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();

        }



        public UserSubscribeDTO GetNumberOfUsersSubs(DateTime startDate, DateTime endDate)
        {
            var parameters = new DynamicParameters();
            parameters.Add("startDate", startDate, DbType.Date, ParameterDirection.Input);
            parameters.Add("endDate", endDate, DbType.Date, ParameterDirection.Input);
            parameters.Add("userCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            dbContext.Connection.Execute("CHANNELSUB_Package.GetNumberOfUsersSubs", parameters, commandType: CommandType.StoredProcedure);

            var userSubscribeDTO = new UserSubscribeDTO
            {
                UserCount = parameters.Get<int>("userCount")
            };

            return userSubscribeDTO;
        }


        public int GetUserSu(int subuesrid)
        {
            var p = new DynamicParameters();
            p.Add("p_subuserid", subuesrid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.QuerySingle<int>("CHANNELSUB_Package.GetNumberSub", p, commandType: CommandType.StoredProcedure);
            return result;
        }




        public void CreateSubscription(SubscribeToChannel subscribeToChannel)

        {

            var p = new DynamicParameters();
            p.Add("p_channel_number", subscribeToChannel.Channelid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_user_id", subscribeToChannel.subuserid, DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("CHANNELSUB_Package.SubscribeToChannel", p, commandType: CommandType.StoredProcedure);


        }


        //public void CheckSubscription(CheckSub checkSub)

        //{

        //    var p = new DynamicParameters();
        //    p.Add("chid", checkSub.Channelid, DbType.Int32, direction: ParameterDirection.Input);
        //    p.Add("subid", checkSub.Subuserid, DbType.Int32, direction: ParameterDirection.Input);


        //    var result = dbContext.Connection.Execute("CHANNELSUB_Package.CHECK_SUBSCRIPTION", p, commandType: CommandType.StoredProcedure);


        //}

        public bool CheckSubscription(CheckSub checkSub)

        {

            var p = new DynamicParameters();
            p.Add("cid", checkSub.Channelid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("subid", checkSub.Subuserid, DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Query<Channelsub>("CHANNELSUB_Package.Cecksub", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault() != null?true:false;

        }


        public CheckSub DeleteSubCh(int p_chid , int p_subid)

        {

            var p = new DynamicParameters();
            p.Add("chid", p_chid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("subid", p_subid, DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Query<CheckSub>("CHANNELSUB_Package.deletesubrow", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();



        }



        public int TotalUserSub()
        {
            int count = dbContext.Connection.QuerySingle<int>("CHANNELSUB_Package.GetTotalUserSub", commandType: CommandType.StoredProcedure);
            return count;
        }




        public List<Channelsub> GetsubBysubuserId(int Subuserid)
        {
            var p = new DynamicParameters();
            p.Add("usid", Subuserid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Query<Channelsub>("CHANNELSUB_Package.get_sub_by_subuserid", p, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }


        public int GetNumberOfUserSub(int Subuserid)
        {
            var p = new DynamicParameters();
            p.Add("usid", Subuserid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.QuerySingle<int>("CHANNELSUB_Package.Get_Number_Of_sub_User", p, commandType: CommandType.StoredProcedure);
            return result;
        }







    }

}

