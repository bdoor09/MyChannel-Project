using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface INotificationService
    {
        void CreateNotification(Notification notification);
        void UpdateNotification(Notification notification);

        void DeleteNotification(int id);
        List<Notification> GetAllNotification();
        Notification GetNotificationByID(int id);

        public bool CheckNotificatio(Notify notify);
        public Notify DeleteNotfyByRId(int p_rid);
    }
}
