using Dapper;
using MyChannel.Core.Commen;
using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Repository
{
    public class NotificationRepoistory: INotificationRepoistory
    {
        private readonly IDbContext dbContext;

        public NotificationRepoistory(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }


        public void CreateNotification(Notification notification)
        {
            var p = new DynamicParameters();
            p.Add("p_message", notification.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_date_of_send", notification.Dtaeofsend, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("p_status", notification.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_report_id", notification.Reportid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("NOTIFICATION_PKG.create_notification", p, commandType: CommandType.StoredProcedure);

        }
        public void UpdateNotification(Notification notification)
        {
            var p = new DynamicParameters();
            p.Add(" p_notification_id", notification.Nid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_message", notification.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_date_of_send", notification.Dtaeofsend, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("p_status", notification.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_report_id", notification.Reportid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("NOTIFICATION_PKG.update_notification", p, commandType: CommandType.StoredProcedure);

        }


        public void DeleteNotification(int id)
        {
            var p = new DynamicParameters();
            p.Add(" p_notification_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("NOTIFICATION_PKG.delete_notification", p, commandType: CommandType.StoredProcedure);
        }

        public List<Notification> GetAllNotification()
        {
            IEnumerable<Notification> result = dbContext.Connection.Query<Notification>("NOTIFICATION_PKG.display_all_notifications", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Notification GetNotificationByID(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_notification_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Notification>("NOTIFICATION_PKG.get_notification_by_id", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }


        public bool CheckNotificatio(Notify notify)

        {

            var p = new DynamicParameters();
            p.Add("rid", notify.ReportId, DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Query<Notification>("NOTIFICATION_PKG.Check_Notification", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault() != null ? true : false;

        }

      
        public Notify DeleteNotfyByRId(int p_rid )

        {

            var p = new DynamicParameters();
            p.Add("rid", p_rid, DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.Connection.Query<Notify>("NOTIFICATION_PKG.Delete_NotificationByRId", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();



        }
    }
}
