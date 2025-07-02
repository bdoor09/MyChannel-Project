using Dapper;
using MyChannel.Core.Commen;
using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Repository
{
    public class ChannelRepository: IChannelRepository
    {
        private readonly IDbContext dbContext;

        public ChannelRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }


        public void CreateChannel(Channel channel)
        {
            var p = new DynamicParameters();
            p.Add("p_channel_name", channel.Channelname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ch", channel.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_image_name", channel.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_user_id", channel.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_backim", channel.Backimage, dbType: DbType.String, direction: ParameterDirection.Input); 



            var result = dbContext.Connection.Execute("CHANNEL_PKG.create_channel", p, commandType: CommandType.StoredProcedure);

        }
        




        public void UpdateChannel(Channel channel)
        {
            var p = new DynamicParameters();
            p.Add("p_channel_id", channel.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_channel_name", channel.Channelname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_ch", channel.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_image_name", channel.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_user_id", channel.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_backim", channel.Backimage, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("CHANNEL_PKG.update_channel", p, commandType: CommandType.StoredProcedure);
        }


        public void DeleteChannel(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_channel_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("CHANNEL_PKG.delete_channel", p, commandType: CommandType.StoredProcedure);

        }
        public List<Channel> GetAllChannel()
        {
            IEnumerable<Channel> result = dbContext.Connection.Query<Channel>("CHANNEL_PKG.display_all_channels", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Channel GetChannelByID(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_channel_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Channel>("CHANNEL_PKG.get_channel_by_id", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public List<SearchChanell> filter (string channelName)
        {
            var p = new DynamicParameters();
            p.Add("Chname", channelName, dbType:DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<SearchChanell>("CHANNEL_PKG.SearchChanell", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public int TotalChannels()
        {
            int count = dbContext.Connection.QuerySingle<int>("CHANNEL_PKG.TotalChannels", commandType: CommandType.StoredProcedure);
            return count;
        }


        public List<Channel> GetChannelsByUserId(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_user_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Channel>("CHANNEL_PKG.get_channels_by_user_id", parameters, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }



        public int countchannel(int Userid)

        {

            var parameters = new DynamicParameters();

            parameters.Add("uid", Userid, DbType.Int32, ParameterDirection.Input);

            int count = dbContext.Connection.QuerySingle<int>("CHANNEL_PKG.GetNumberOfchannel", parameters, commandType: CommandType.StoredProcedure);

            return count;

        }


    }
}
