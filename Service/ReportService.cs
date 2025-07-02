using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using MyChannel.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Service
{
    public class ReportService: IReportService
    {
        private readonly IReportRepoistory ReportRepoistory;

        public ReportService(IReportRepoistory _reportRepoistory)
        {
            this.ReportRepoistory = _reportRepoistory;
        }


        public void CreateReport(Report report)
        {
            ReportRepoistory.CreateReport(report);
        }

        public void UpdateReport(Report report)
        {
            ReportRepoistory.UpdateReport(report);
        }

        public void DeleteReport(int id)
        {
            ReportRepoistory.DeleteReport(id);
        }

        public List<Report> GetAllReport()
        {
            return ReportRepoistory.GetAllReport();
        }


        public Report GetReportByID(int id)
        {
            return ReportRepoistory.GetReportByID(id);
        }

        public SearchReDate filter(DateTime DateFrom, DateTime DateTo)
        {
            return ReportRepoistory.filter(DateFrom, DateTo);
        }

        public List<ReportsForChannelDTO> GetReportsForChannelByName(string channelName)
        {
            return ReportRepoistory.GetReportsForChannelByName(channelName);
        }

        public List<RepotChanel> GetAllReportChannel()
        {
            return ReportRepoistory.GetAllReportChannel();
        }
        public int TotalReport(TotalReportBydate totalReportBydate)
        {
            return ReportRepoistory.TotalReport(totalReportBydate);
        }

        public int TotalReport()
        {
            return ReportRepoistory.TotalReport();  
        }



    }
}
