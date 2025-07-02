using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Repository
{
    public interface IReportRepoistory
    {
        void CreateReport(Report report);
        void UpdateReport(Report report);
        void DeleteReport(int id);
        List<Report> GetAllReport();
        Report GetReportByID(int id);

        public SearchReDate filter(DateTime DateFrom, DateTime DateTo);

        List<ReportsForChannelDTO> GetReportsForChannelByName(string channelName);

         List<RepotChanel> GetAllReportChannel();

         int TotalReport(TotalReportBydate totalReportBydate);

         int TotalReport();

    }
}
