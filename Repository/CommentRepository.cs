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
    public class CommentRepository: ICommentRepository
    {
        private readonly IDbContext dbContext;

        public CommentRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Comment> GetAllComments()
        {
            IEnumerable<Comment> result = dbContext.Connection.Query<Comment>("Comment_Package.GetAllComments", commandType: CommandType.StoredProcedure);
            return result.ToList();
     
        }

        public void CreateComment(Comment comment)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CONT", comment.Content, DbType.String, ParameterDirection.Input);
            parameters.Add("COMMENT_DATE", comment.Commentdate, DbType.Date, ParameterDirection.Input);
            parameters.Add("VIDEO_ID", comment.Videoid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("User_ID", comment.Userid, DbType.Int32, ParameterDirection.Input); // Add UserId parameter

            var result = dbContext.Connection.Execute("Comment_Package.CreateComment", parameters, commandType: CommandType.StoredProcedure);
        }

        public void UpdateComment(Comment comment)
        {
            var parameters = new DynamicParameters();
            parameters.Add("cid", comment.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CONT", comment.Content, DbType.String, ParameterDirection.Input);
            parameters.Add("COMMENT_DATE", comment.Commentdate, DbType.Date, ParameterDirection.Input);
            parameters.Add("VIDEO_ID", comment.Videoid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("User_ID", comment.Userid, DbType.Int32, ParameterDirection.Input); // Add UserId parameter

            var result = dbContext.Connection.Execute("Comment_Package.UpdateComment", parameters, commandType: CommandType.StoredProcedure);
        }

        public void DeleteComment(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("cid", id, DbType.Int32, ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Comment_Package.DeleteComment", parameters, commandType: CommandType.StoredProcedure);
        }

        public Comment GetCommentById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("cid", id, DbType.Int32, ParameterDirection.Input);

            var result = dbContext.Connection.Query<Comment>(" Comment_Package.GetCommentById", parameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }




        public List<CommentDto> GetCommentsByVideoId(int videoId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("vidid", videoId, DbType.Int32, ParameterDirection.Input);

            var result = dbContext.Connection.Query<CommentDto>(" Comment_Package.GetCommentsByVideoId", parameters, commandType: CommandType.StoredProcedure).Select(a => new CommentDto
            {
                Id = a.Id,
                Content = a.Content,
                FirstName = a.FirstName,
                LastName = a.LastName,
                CommentDate = a.CommentDate,
                Image = a.Image,
                Videoid = a.Videoid
            });
            return result.ToList();
        }


        public int TotalComment(int vid)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_vid", vid, DbType.Int32, ParameterDirection.Input);

            int count = dbContext.Connection.QuerySingle<int>("Comment_Package.TotalComment", parameters, commandType: CommandType.StoredProcedure);
            return count;
        }
    }
}
