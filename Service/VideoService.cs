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
    public class VideoService: IVideoService
    {
        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public List<Video> GetAllVideos()
        {
            return _videoRepository.GetAllVideos();
        }

        public void CreateVideo(Video video)
        {
            _videoRepository.CreateVideo(video);
        }

        public void UpdateVideo(Video video)
        {
            _videoRepository.UpdateVideo(video);
        }

        public void DeleteVideo(int id)
        {
            _videoRepository.DeleteVideo(id);
        }

        public Video GetVideoById(int id)
        {
            return _videoRepository.GetVideoById(id);
        }

        public List<VideosOnEachChannelDTO> VideosOnEachChannel()
        {
            return _videoRepository.VideosOnEachChannel();
        }

        public int TotalVideo()
        {
           return _videoRepository.TotalVideo();
        }


        public void UpdateLikeInc(int Id)
        {
            _videoRepository.UpdateLikeInc(Id);
        }

        public void UpdateDislikeInc(int Id)
        {
            _videoRepository.UpdateDislikeInc(Id);
        }
        public void UpdateLikeDec(int Id)
        {
            _videoRepository.UpdateLikeDec(Id);
        }

        public void UpdateDislikeDec(int Id)
        {
            _videoRepository.UpdateDislikeDec(Id);
        }

        public List<Video> GetVideoByChannelId(int Channelid)
        {
            return _videoRepository.GetVideoByChannelId(Channelid);
        }



      public List<UserVideos> GetVideoByuserId(int userid)
        {
            return _videoRepository.GetVideoByuserId(userid);
        }
    }
}
