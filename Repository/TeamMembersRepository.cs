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
    public class TeamMembersRepository: ITeamMembersRepository
    {
        private readonly IDbContext dbContext;
        public TeamMembersRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Teammember> GetAllTeam()
        {
            IEnumerable<Teammember> result = dbContext.Connection.Query<Teammember>("TEAMMEMBERS_Package.GET_ALL", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Teammember GetTeamById(int id)
        {
            var p = new DynamicParameters();
            p.Add("tid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Teammember>("TEAMMEMBERS_Package.GET_TEAMMEMBERS_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateTeam(Teammember teammember)
        {
            var p = new DynamicParameters();
            p.Add("MEMBERNAMES", teammember.Membername, DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLES", teammember.Role, DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGENAMES", teammember.Imagename, DbType.String, direction: ParameterDirection.Input);
            p.Add("EMAILS", teammember.Email, DbType.String, direction: ParameterDirection.Input);
            p.Add("HOMESID", teammember.Homeid, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("PHON", teammember.Phonenumber, DbType.String, direction: ParameterDirection.Input);
            p.Add("LIN", teammember.Linkedin, DbType.String, direction: ParameterDirection.Input);




            var result = dbContext.Connection.Execute("TEAMMEMBERS_Package.CREAT_NEW_TEAMMEMBERS", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateTeam(Teammember teammember)
        {
            var p = new DynamicParameters();
            p.Add("tid", teammember.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("MEMBERNAMES", teammember.Membername, DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLES", teammember.Role, DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGENAMES", teammember.Imagename, DbType.String, direction: ParameterDirection.Input);
            p.Add("EMAILS", teammember.Email, DbType.String, direction: ParameterDirection.Input);
            p.Add("PHON", teammember.Phonenumber, DbType.String, direction: ParameterDirection.Input);
            p.Add("LIN", teammember.Linkedin, DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("TEAMMEMBERS_Package.UPDATE_TEAMMEMBERS", p, commandType: CommandType.StoredProcedure);

        }

        public Teammember DeleteTeam(int id)
        {
            var p = new DynamicParameters();
            p.Add("tid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Teammember>("TEAMMEMBERS_Package.DELETE_TEAMMEMBERS", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
