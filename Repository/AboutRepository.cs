using Dapper;
using MyChannel.Core.Commen;
using MyChannel.Core.Data;
using MyChannel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Repository
{
    public class AboutRepository: IAboutRepository
    {
        private readonly IDbContext dbContext;
        public AboutRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<About> GetAllAbout()
        {
            IEnumerable<About> result = dbContext.Connection.Query<About>("About_Package.GET_ALL", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public About GetAboutById(int id)
        {
            var p = new DynamicParameters();
            p.Add("aid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<About>("About_Package.GET_ABOUT_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateAbout(About about)
        {
            var p = new DynamicParameters();
            p.Add("TITLES", about.Title, DbType.String, direction: ParameterDirection.Input);
            p.Add("CONTENT", about.Contents, DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGENAMES", about.Imagename, DbType.String, direction: ParameterDirection.Input);
            p.Add("HOMESID", about.Homeid, DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("About_Package.CREAT_NEW_ABOUT", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateAbout(About about)
        {
            var p = new DynamicParameters();
            p.Add("aid", about.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TITLES", about.Title, DbType.String, direction: ParameterDirection.Input);
            p.Add("CONTENT", about.Contents, DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGENAMES", about.Imagename, DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("About_Package.UPDATE_ABOUT", p, commandType: CommandType.StoredProcedure);

        }

        public About DeleteAbout(int id)
        {
            var p = new DynamicParameters();
            p.Add("aid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<About>("About_Package.DELETE_ABOUT", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
