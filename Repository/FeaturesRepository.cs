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
    public class FeaturesRepository: IFeaturesRepository
    {
        private readonly IDbContext dbContext;
        public FeaturesRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Feature> GetAllFEATURES()
        {
            IEnumerable<Feature> result = dbContext.Connection.Query<Feature>("FEATURES_Package.GET_ALL", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Feature GetFEATURESById(int id)
        {
            var p = new DynamicParameters();
            p.Add("fid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Feature>("FEATURES_Package.GET_FEATURES_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateFEATURES(Feature feature)
        {
            var p = new DynamicParameters();
            p.Add("TITLES", feature.Title, DbType.String, direction: ParameterDirection.Input);
            p.Add("conttent1", feature.Con1, DbType.String, direction: ParameterDirection.Input);
            p.Add("conttent2", feature.Con2, DbType.String, direction: ParameterDirection.Input);
            p.Add("conttent3", feature.Con3, DbType.String, direction: ParameterDirection.Input);
            p.Add("image", feature.Imagename, DbType.String, direction: ParameterDirection.Input);
            p.Add("HOMESID", feature.Homeid, DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Execute("FEATURES_Package.CREAT_NEW_FEATURES", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateFEATURES(Feature feature)
        {
            var p = new DynamicParameters();
            p.Add("fid", feature.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("TITLES", feature.Title, DbType.String, direction: ParameterDirection.Input);
            p.Add("conttent1", feature.Con1, DbType.String, direction: ParameterDirection.Input);
            p.Add("conttent2", feature.Con2, DbType.String, direction: ParameterDirection.Input);
            p.Add("conttent3", feature.Con3, DbType.String, direction: ParameterDirection.Input);
            p.Add("image", feature.Imagename, DbType.String, direction: ParameterDirection.Input);
            p.Add("HOMESID", feature.Homeid, DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("FEATURES_Package.UPDATE_FEATURES", p, commandType: CommandType.StoredProcedure);

        }

        public Feature DeleteFEATURES(int id)
        {
            var p = new DynamicParameters();
            p.Add("fid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Feature>("FEATURES_Package.DELETE_FEATURES", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

    }
}
