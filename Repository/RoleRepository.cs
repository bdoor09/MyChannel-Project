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
    public class RoleRepository: IRoleRepository
    {
        private readonly IDbContext dbContext;

        public RoleRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Role> GetallRole()
        {
            IEnumerable<Role> result = dbContext.Connection.Query<Role>("ROLE_PACKAGE.GetAllRole", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("role_name", role.Rolename, DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("ROLE_PACKAGE.CreateRole", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("RID", role.Id, DbType.Int32, direction: ParameterDirection.Input);
            p.Add("role_name", role.Rolename, DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("ROLE_PACKAGE.UpdateRole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("RID", id, DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("ROLE_PACKAGE.DeleteRole", p, commandType: CommandType.StoredProcedure);
        }

        public Role GetRoleById(int id)
        {
            var p = new DynamicParameters();
            p.Add("RID", id, DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Query<Role>("ROLE_PACKAGE.GetRoleByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
