using Dapper;
using MyChannel.Core.Commen;
using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Repository
{
    public class ReportRepoistory: IReportRepoistory
    {
        //Instance == inject to IDbContext

        private readonly IDbContext dbContext;

        public ReportRepoistory(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }



        public void CreateReport(Report report)
        {
            var p = new DynamicParameters();
            p.Add("p_content", report.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_date_of_send", report.Dtaeofsend, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("p_channel_id", report.Channelid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("r_status", report.Status, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("REPORT_PKG.create_report", p, commandType: CommandType.StoredProcedure);


        }

        public void UpdateReport(Report report)
        {
            var p = new DynamicParameters();
            p.Add("p_report_id", report.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_content", report.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_date_of_send", report.Dtaeofsend, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("p_channel_id", report.Channelid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("r_status", report.Status, dbType: DbType.String, direction: ParameterDirection.Input);

            

            var result = dbContext.Connection.ExecuteAsync("REPORT_PKG.update_report", p, commandType: CommandType.StoredProcedure);

        }

        public void DeleteReport(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_report_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("REPORT_PKG.delete_report", p, commandType: CommandType.StoredProcedure);
        }


        public List<Report> GetAllReport()
        {
            IEnumerable<Report> result = dbContext.Connection.Query<Report>("REPORT_PKG.display_all_reports", commandType: CommandType.StoredProcedure);


            return result.ToList();

        }


        public Report GetReportByID(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_report_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Query<Report>("REPORT_PKG.get_report_by_id", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public SearchReDate  filter (DateTime DateFrom,  DateTime DateTo)
        {
            var p = new DynamicParameters();
            p.Add("DateFrom", DateFrom, dbType: DbType.Date, direction:ParameterDirection.Input);
            p.Add("DateTo", DateTo, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<SearchReDate>("REPORT_PKG.SearchReDate", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();


        }



        public List<ReportsForChannelDTO> GetReportsForChannelByName(string channelName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("channel_name", channelName, DbType.String, ParameterDirection.Input);

            var result = dbContext.Connection.Query<ReportsForChannelDTO>("REPORT_PKG.GetReportsForChannelByName", parameters, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }



        public List<RepotChanel> GetAllReportChannel()
        {
            IEnumerable<RepotChanel> result = dbContext.Connection.Query<RepotChanel>("REPORT_PKG.GetReportChannel", commandType: CommandType.StoredProcedure);


            return result.ToList();

        }




        public int TotalReport(TotalReportBydate totalReportBydate)
        {
            var p = new DynamicParameters();
            p.Add("DateFrom", totalReportBydate.dateFrom, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("DateTo", totalReportBydate.dateTo, dbType: DbType.Date, direction: ParameterDirection.Input);

            // Specify the parameters in the stored procedure call
            int count = dbContext.Connection.QuerySingle<int>(
                "REPORT_PKG.SearchReDateCount",
                p,  // Pass the parameters
                commandType: CommandType.StoredProcedure
            );

            return count;
        }

        public int TotalReport()
        {
            int count = dbContext.Connection.QuerySingle<int>("REPORT_PKG.GetNumberOfReport", commandType: CommandType.StoredProcedure);
            return count;
        }








    }
}
