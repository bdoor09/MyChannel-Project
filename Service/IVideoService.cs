using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface IVideoService
    {
    
        List<Video> GetAllVideos();
        void CreateVideo(Video video);
        void UpdateVideo(Video video);
        void DeleteVideo(int id);
        Video GetVideoById(int id);

        List<VideosOnEachChannelDTO> VideosOnEachChannel();

        public int TotalVideo();

        void UpdateLikeInc(int Id);
        void UpdateDislikeInc(int Id);
        void UpdateLikeDec(int Id);
        void UpdateDislikeDec(int Id);
        List<Video> GetVideoByChannelId(int Channelid);

        List<UserVideos> GetVideoByuserId(int userid);
    }
}
