using Azure;
using Dapper;
using MyChannel.Core.Commen;
using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Repository
{
    public class VideoRepository: IVideoRepository
    {
        private readonly IDbContext dbContext;

        public VideoRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Video> GetAllVideos()
        {
            IEnumerable<Video> result = dbContext.Connection.Query<Video>("Video_Package.GetAll_Videos", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateVideo(Video video)
        {
            var parameters = new DynamicParameters();
            parameters.Add("VIDEO_TITLE", video.Videotitle, DbType.String, ParameterDirection.Input);
            parameters.Add("VIDEO_URL", video.Videourl, DbType.String, ParameterDirection.Input);
            parameters.Add("SIZE_OF_VIDEO", video.Sizeofvideo, DbType.Int32, ParameterDirection.Input);
            parameters.Add("des", video.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("CHANNEL_ID", video.Channelid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("NO_LIKE", video.Numberoflike, DbType.Int32, ParameterDirection.Input);
            parameters.Add("NO_DISLIKE", video.Numberofdislike, DbType.Int32, ParameterDirection.Input);
            parameters.Add("NO_DISPLAY", video.Numberofdisplay, DbType.Int32, ParameterDirection.Input);
            parameters.Add("LOAD_DATE", video.Uploadedate, DbType.Date, ParameterDirection.Input);
            parameters.Add("image", video.Imageurl, DbType.String, ParameterDirection.Input);


            var result = dbContext.Connection.Execute("Video_Package.CreateVideo", parameters, commandType: CommandType.StoredProcedure);

        }
        public void UpdateVideo(Video video)
        {
            var parameters = new DynamicParameters();
            parameters.Add("vid", video.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("VIDEO_TITLE", video.Videotitle, DbType.String, ParameterDirection.Input);
            parameters.Add("VIDEO_URL", video.Videourl, DbType.String, ParameterDirection.Input);
            parameters.Add("des", video.Description, DbType.String, ParameterDirection.Input);
            parameters.Add("CHANNEL_ID", video.Channelid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("image", video.Imageurl, DbType.String, ParameterDirection.Input);


            var result = dbContext.Connection.Execute("Video_Package.UpdateVideo", parameters, commandType: CommandType.StoredProcedure);
        }

        public void DeleteVideo(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("vid", id, DbType.Int32, ParameterDirection.Input);

             var result = dbContext.Connection.Execute("Video_Package.DeleteVideo", parameters, commandType: CommandType.StoredProcedure);
        }

        public Video GetVideoById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("vid", id, DbType.Int32, ParameterDirection.Input);

            var result = dbContext.Connection.Query<Video>("Video_Package.GetVideoById", parameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<VideosOnEachChannelDTO> VideosOnEachChannel()
        {
            var result = dbContext.Connection.Query<VideosOnEachChannelDTO>("Video_Package.VideosOnEachChannel", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public int TotalVideo()
        {
            int count = dbContext.Connection.QuerySingle<int>("Video_Package.TotalVideos", commandType: CommandType.StoredProcedure);
            return count;
        }



        public void UpdateLikeInc(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("vid", Id, DbType.Int32, ParameterDirection.Input);

            dbContext.Connection.Execute("Video_Package.update_like_inc", parameters, commandType: CommandType.StoredProcedure);
        }

        public void UpdateDislikeInc(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("vid", Id, DbType.Int32, ParameterDirection.Input);

            dbContext.Connection.Execute("Video_Package.update_dislike_inc", parameters, commandType: CommandType.StoredProcedure);
        }
        public void UpdateLikeDec(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("vid", Id, DbType.Int32, ParameterDirection.Input);

            dbContext.Connection.Execute("Video_Package.update_like_dic", parameters, commandType: CommandType.StoredProcedure);
        }

        public void UpdateDislikeDec(int Id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("vid", Id, DbType.Int32, ParameterDirection.Input);

            dbContext.Connection.Execute("Video_Package.update_dislike_dic", parameters, commandType: CommandType.StoredProcedure);
        }

        public List<Video> GetVideoByChannelId(int Channelid)
        {
            var parameters = new DynamicParameters();
            parameters.Add("cid", Channelid, DbType.Int32, ParameterDirection.Input);

            var result = dbContext.Connection.Query<Video>("Video_Package.GetVideoBychannelId", parameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public List<UserVideos> GetVideoByuserId(int userid)
        {
            var parameters = new DynamicParameters();
            parameters.Add("uid", userid, DbType.Int32, ParameterDirection.Input);

            var result = dbContext.Connection.Query<UserVideos>("Video_Package.getvideouser", parameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }








    }
}
