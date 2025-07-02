using Azure;
using Dapper;
using MyChannel.Core.Commen;
using MyChannel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System.Runtime.InteropServices;

namespace MyChannel.Infra.Repository
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly IDbContext dbContext;

        public ResponseRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Respon> GetAllResponses()
        {
            IEnumerable<Respon> result = dbContext.Connection.Query<Respon>("Respons_Package.GetAllResponses", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateResponse(Respon respon)
        {
            var parameters = new DynamicParameters();
            parameters.Add("REPLAY_COMMENT", respon.Replaycomment, DbType.String, ParameterDirection.Input);
            parameters.Add("COMMENT_ID", respon.Commentid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("User_ID", respon.Usercid, DbType.Int32, ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Respons_Package.CreateResponse", parameters, commandType: CommandType.StoredProcedure);
        }

        public void UpdateResponse(Respon respon)
        {
            var parameters = new DynamicParameters();
            parameters.Add("rid", respon.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("REPLAY_COMMENT", respon.Replaycomment, DbType.String, ParameterDirection.Input);
            parameters.Add("COMMENT_ID", respon.Commentid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("User_ID", respon.Usercid, DbType.Int32, ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Respons_Package.UpdateResponse", parameters, commandType: CommandType.StoredProcedure);
        }

        public void DeleteResponse(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("rid", id, DbType.Int32, ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Respons_Package.DeleteResponse", parameters, commandType: CommandType.StoredProcedure);
        }

        public Respon GetResponseById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("rid", id, DbType.Int32, ParameterDirection.Input);

            var result = dbContext.Connection.Query<Respon>("Respons_Package.GetResponseById", parameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<ResponsDTO> GetResponsByCommentid(int Commentid)

        {

            var parameters = new DynamicParameters();

            parameters.Add("cid", Commentid, DbType.Int32, ParameterDirection.Input);

            var result = dbContext.Connection.Query<ResponsDTO>(" Respons_Package.GetResponsByCommentid", parameters, commandType: CommandType.StoredProcedure);

            return result.ToList();

        }



    }
}
