using Dapper;
using MyChannel.Core;
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
    public class HomeRepository: IHomeRepository
    {
        private readonly IDbContext dbContext;
        public HomeRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Home> GetAllHome()
        {
            IEnumerable<Home> result = dbContext.Connection.Query<Home>("Home_Package.GET_ALL", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Home GetHomeById(int id)
        {
            var p = new DynamicParameters();
            p.Add("hid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Home>("Home_Package.GET_HOME_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateHome(Home home)
        {
            var p = new DynamicParameters();
            p.Add("TITLES", home.Title, DbType.String, direction: ParameterDirection.Input);
            p.Add("CONTENT", home.Contents, DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGENAMES", home.Imagename, DbType.String, direction: ParameterDirection.Input);
            p.Add("FOTERID", home.Footerid, DbType.Int32, direction: ParameterDirection.Input);



            var result = dbContext.Connection.Execute("Home_Package.CREAT_NEW_HOME", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateHome(Home home)
        {
            var p = new DynamicParameters();
            p.Add("hid", home.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TITLES", home.Title, DbType.String, direction: ParameterDirection.Input);
            p.Add("CONTENT", home.Contents, DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGENAMES", home.Imagename, DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Home_Package.UPDATE_HOME", p, commandType: CommandType.StoredProcedure);

        }

        public Home DeleteHome(int id)
        {
            var p = new DynamicParameters();
            p.Add("hid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Home>("Home_Package.DELETE_HOME", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
