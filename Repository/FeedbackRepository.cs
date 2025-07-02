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
    public class FeedbackRepository: IFeedbackRepository
    {
        private readonly IDbContext dbContext;
        public FeedbackRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Feedback> GetallFeedback()
        {
            IEnumerable<Feedback> result = dbContext.Connection.Query<Feedback>("FEEDBACK_PACKAGE.GetAllFeedback", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateFeedback(Feedback feedback)
        {
            var p = new DynamicParameters();
            p.Add("con",feedback.Content,DbType.String,direction: ParameterDirection.Input);
            p.Add("date_send", feedback.Dtaeofsend, DbType.Date, direction: ParameterDirection.Input);
            p.Add("user_id", feedback.Userid, DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("FEEDBACK_PACKAGE.CreateFeedback",p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateFeedback(Feedback feedback)
        {
            var p = new DynamicParameters();
            p.Add("FID",feedback.Id,DbType.Int32,direction: ParameterDirection.Input);
            p.Add("con", feedback.Content, DbType.String, direction: ParameterDirection.Input);
            p.Add("date_send", feedback.Dtaeofsend, DbType.Date, direction: ParameterDirection.Input);
            p.Add("user_id", feedback.Userid, DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("FEEDBACK_PACKAGE.UpdateFeedback", p, commandType: CommandType.StoredProcedure);
        }

        public void DelteFeedback(int id)
        {
            var p = new DynamicParameters();
            p.Add("FID", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("FEEDBACK_PACKAGE.DeleteFeedback", p, commandType: CommandType.StoredProcedure);
        }
        public Feedback GetFeedbackById(int id)
        {
            var p = new DynamicParameters();
            p.Add("FID", id, DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Feedback>("FEEDBACK_PACKAGE.GetFeedbackByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public List<GetFeedbackuser> GetallFeedbackUser()
        {
            IEnumerable<GetFeedbackuser> result = dbContext.Connection.Query<GetFeedbackuser>("FEEDBACK_PACKAGE.GetFeedbachuser", commandType: CommandType.StoredProcedure);

            return result.ToList();


        }

        public List<top4feedback> topfourfeedback()
        {
            IEnumerable<top4feedback> result = dbContext.Connection.Query<top4feedback>("FEEDBACK_PACKAGE.GetTop4FeedbackUser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



    }
}
