using Dapper;
using MyChannel.Core;
using MyChannel.Core.Commen;
using MyChannel.Core.Data;
using MyChannel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Repository
{
    public class FooterRepository: IFooterRepository
    {
        private readonly IDbContext dbContext;
        public FooterRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Footer> GetAllFooter()
        {

            IEnumerable<Footer> result = dbContext.Connection.Query<Footer>("Footer_Package.GET_ALL", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Footer GetFooterById(int id)
        {
            var p = new DynamicParameters();
            p.Add("fid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Footer>("Footer_Package.GET_FOOTER_BY_ID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateFooter(Footer footer)
        {
            var p = new DynamicParameters();
            p.Add("Xaccount", footer.X, DbType.String, direction: ParameterDirection.Input);
            p.Add("FACEBOOKaccount", footer.Facebook, DbType.String, direction: ParameterDirection.Input);
            p.Add("INSTAGRAMaccount", footer.Instagram, DbType.String, direction: ParameterDirection.Input);
            p.Add("WHATSAPPaccount", footer.Whatsapp, DbType.String, direction: ParameterDirection.Input);
            p.Add("GMAILaccount", footer.Gmail, DbType.String, direction: ParameterDirection.Input);
            p.Add("con", footer.Contents, DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Footer_Package.CREAT_NEW_FOOTER", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateFootert(Footer footer)

        {

            var p = new DynamicParameters();

            p.Add("fid", footer.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Xaccount", footer.X, DbType.String, direction: ParameterDirection.Input);
            p.Add("FACEBOOKaccount", footer.Facebook, DbType.String, direction: ParameterDirection.Input);
            p.Add("INSTAGRAMaccount", footer.Instagram, DbType.String, direction: ParameterDirection.Input);
            p.Add("WHATSAPPaccount", footer.Whatsapp, DbType.String, direction: ParameterDirection.Input);
            p.Add("GMAILaccount", footer.Gmail, DbType.String, direction: ParameterDirection.Input);
            p.Add("con", footer.Contents, DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("Footer_Package.UPDATE_FOOTER", p, commandType: CommandType.StoredProcedure);

        }
        public Footer DeleteFooter(int id)
        {
            var p = new DynamicParameters();
            p.Add("fid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Footer>("Footer_Package.DELETE_FOOTER", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
