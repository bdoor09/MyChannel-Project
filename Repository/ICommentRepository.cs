using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Repository
{
    public interface ICommentRepository
    {
        List<Comment> GetAllComments();
        void CreateComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int id);
        Comment GetCommentById(int id);

        List<CommentDto> GetCommentsByVideoId(int videoId);

        int TotalComment(int vid);
    }
}
