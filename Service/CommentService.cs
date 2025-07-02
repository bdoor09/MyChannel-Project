using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using MyChannel.Core.Service;
using MyChannel.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Service
{
    public class CommentService: ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository _commentRepository)
        {
            commentRepository = _commentRepository;
        }

        public List<Comment> GetAllComments()
        {
            return commentRepository.GetAllComments();
        }

        public void CreateComment(Comment comment)
        {
            commentRepository.CreateComment(comment);
        }

        public void UpdateComment(Comment comment)
        {
            commentRepository.UpdateComment(comment);
        }

        public void DeleteComment(int id)
        {
            commentRepository.DeleteComment(id);
        }

        public Comment GetCommentById(int id)
        {
            return commentRepository.GetCommentById(id);
        }


        public List<CommentDto> GetCommentsByVideoId(int videoId)
        {
            return commentRepository.GetCommentsByVideoId((int)videoId);
        }


        public int TotalComment(int vid)
        {
            return commentRepository.TotalComment(vid);
        }


    }
}
