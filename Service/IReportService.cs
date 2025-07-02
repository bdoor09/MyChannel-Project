using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface IReportService
    {
        void CreateReport(Report report);
        void UpdateReport(Report report);
        void DeleteReport(int id);
        List<Report> GetAllReport();
        Report GetReportByID(int id);

         SearchReDate filter(DateTime DateFrom, DateTime DateTo);

        List<ReportsForChannelDTO> GetReportsForChannelByName(string channelName);

         List<RepotChanel> GetAllReportChannel();
        public int TotalReport(TotalReportBydate totalReportBydate);

        public int TotalReport();
    }
}
